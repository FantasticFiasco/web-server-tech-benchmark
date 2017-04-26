(ns benchmark.relay
  (:require [org.httpkit.client :as http]
            [clojure.data.json :as json]))

(def hostname (System/getenv "Relay_KeyValueServiceHostname"))
(def port (System/getenv "Relay_KeyValueServicePort"))

(def url 
  (str "http://" hostname ":" port "/store/"))

(defn build-response-body [key data]
  (json/write-str
    {
      "key"   key
      "value" (get (json/read-str data) "value")
    }))

(defn handler [req]
  (let [key (-> req :params :key)]
    (let [response (http/get (str url key))]
      {
        :status  (:status @response)
        :headers {"Content-Type" "application/json"}
        :body    (build-response-body key (:body @response))
      })))