(ns benchmark.echo)

(defn handler [req]
  {:status  200
   :headers {"Content-Type" "text/plain"}
   :body    (-> req :params :text)})
