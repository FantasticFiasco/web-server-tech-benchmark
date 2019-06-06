(defproject benchmark "0.1.0-SNAPSHOT"
  :description "Minimal webserver"
  :url "http://example.com/FIXME"
  :license {:name "Eclipse Public License"
            :url "http://www.eclipse.org/legal/epl-v10.html"}
  :dependencies [[org.clojure/clojure "1.10.1"]
                 [javax.servlet/servlet-api "2.5"]
                 [ring/ring-core "1.7.1"]
                 [http-kit "2.3.0"]
                 [compojure "1.6.1"]
                 [org.clojure/data.json "0.2.6"]
                 [alaisi/postgres.async "0.8.0"]]
  :main ^:skip-aot benchmark.core
  :target-path "target/%s"
  :profiles {:uberjar {:aot :all}})
