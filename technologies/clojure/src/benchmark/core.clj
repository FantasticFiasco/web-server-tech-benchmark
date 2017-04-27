(ns benchmark.core
  (:use [compojure.route :only [files not-found]]
        [compojure.handler :only [site]]
        [compojure.core :only [defroutes GET POST DELETE ANY context]])
  (:require [benchmark.health :as health]
            [benchmark.echo :as echo]
            [benchmark.relay :as relay]
            [benchmark.contacts :as contacts]
            [org.httpkit.server :as http]))

(defroutes all-routes
  (GET "/health" [] health/handler)
  (GET "/echo/:text" [] echo/handler)
  (GET "/relay/:key" [] relay/handler)
  (context "/contacts" []
          (GET "/" [] contacts/get-all-handler)
          (POST "/" [] contacts/create-handler)
          (GET "/:id" [] contacts/get-handler)
          (DELETE "/:id" [] contacts/delete-handler))
  (not-found "<p>Page not found.</p>"))

(defn -main [& args]
  (http/run-server (site #'all-routes) {:port 8090})
  (println "Server started"))