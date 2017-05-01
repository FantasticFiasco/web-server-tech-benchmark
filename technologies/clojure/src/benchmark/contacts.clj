(ns benchmark.contacts
  (require [postgres.async :as pg]
           [clojure.data.json :as json]
           [org.httpkit.server :as http]))

(def db (pg/open-db {:hostname (System/getenv "Contacts_DatabaseHost")
                  :port 5432
                  :database (System/getenv "Contacts_DatabaseName")
                  :username (System/getenv "Contacts_DatabaseUsername")
                  :password (System/getenv "Contacts_DatabasePassword")
                  :pool-size 300}))


(defn create-json-response [status body]
  {
    :status status
    :headers {"Content-Type" "application/json"}
    :body    body
  })


(defn create-json-response-with-location [status body location] 
  (assoc-in
    (create-json-response status body) [:headers "location"] location))

(defn key-writer [key]
  (if (= key :firstname)
    "firstName"
    (name key)))

(defn get-all-handler [req]
  (http/with-channel req channel
    (pg/execute! db ["select id, firstName, surname from contact"] 
      (fn [rs err]        
        (http/send! channel 
          (create-json-response 200 (json/write-str (:rows rs) :key-fn key-writer)) true)))))

(defn create-handler [req]
  (http/with-channel req channel
    (let [request-body (json/read-str (slurp (:body req)))
          firstName (get request-body "firstName")
          surname (get request-body "surname")]
      (pg/insert! db {:table "contact", :returning "id"} {:firstname firstName :surname surname}
        (fn [rs err] 
          (let [result (first (:rows rs))]
            (http/send! channel 
              (create-json-response-with-location 
                201 
                (json/write-str (assoc result :firstName firstName :surname surname))
                (str "http://" (:server-name req) ":8090/contacts/" (:id result))
              ) true)))))))

(defn get-handler [req]
  (http/with-channel req channel
    (let [id (-> req :params :id)]
      (pg/execute! db ["select id, firstName, surname from contact where id = $1" id]
        (fn [rs err]
          (http/send! channel
            (create-json-response 200 (json/write-str (first (:rows rs)) :key-fn key-writer)) true))))))

(defn delete-handler [req]
  (http/with-channel req channel
    (let [id (-> req :params :id)]
      (pg/execute! db ["delete from contact where id = $1" id] 
        (fn [rs err] 
          (http/send! channel 
            {:status  204} true))))))