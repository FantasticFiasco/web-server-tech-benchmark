(ns benchmark.contacts
  (require [postgres.async :as pg]
           [clojure.data.json :as json]
           [org.httpkit.server :as http]))

(def hostname (System/getenv "Contacts_DatabaseHost"))
(def port 5432)

(def db (pg/open-db {:hostname hostname
                  :port port
                  :database (System/getenv "Contacts_DatabaseName")
                  :username (System/getenv "Contacts_DatabaseUsername")
                  :password (System/getenv "Contacts_DatabasePassword")
                  :pool-size 10}))

(defn create-json-response [status body]
  {
    :status status
    :headers {"Content-Type" "application/json"}
    :body    body
  })

(defn get-all-handler [req]
  (http/with-channel req channel
    (pg/execute! db ["select id, firstName, surname from contact"] 
      (fn [rs err]        
        (http/send! channel 
          (create-json-response 200 (json/write-str (:rows rs))) true)))))

(defn create-handler [req]
  (http/with-channel req channel
    (let [request-body (json/read-str (slurp (:body req)))
          firstName (get request-body "firstName")
          surname (get request-body "surname")]
      (pg/insert! db {:table "contact", :returning "id"} {:firstname firstName :surname surname}
        (fn [rs err] 
          (let [result (first (:rows rs))]
            (http/send! channel 
              {
                :status  201
                :headers {"Content-Type" "application/json" 
                          "Location" (str "http://" hostname ":" port "/contacts/" (:id result))}
                :body    (json/write-str (assoc result :firstName firstName :surname surname))
              } true)))))))

(defn get-handler [req]
  (http/with-channel req channel
    (let [id (-> req :params :id)]
      (pg/execute! db ["select id, firstName, surname from contact where id = $1" id] 
        (fn [rs err]           
          (http/send! channel 
            (create-json-response 200 (json/write-str (first (:rows rs)))) true))))))


(defn delete-handler [req]
  (http/with-channel req channel
    (let [id (-> req :params :id)]
      (pg/execute! db ["delete from contact where id = $1" id] 
        (fn [rs err] 
          (http/send! channel 
            {:status  204} true))))))