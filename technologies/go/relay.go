package main

import (
	"fmt"
	"github.com/julienschmidt/httprouter"
	"net/http"
	"io/ioutil"
	"os"
)

var relayServiceHostname = os.Getenv("Relay:KeyValueServiceHostname")
var relayServicePort = os.Getenv("Relay:KeyValueServicePort")

func Relay(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	key := ps.ByName("key")
	url := fmt.Sprintf("http://%s:%s/store/%s", relayServiceHostname, relayServicePort, key)

	resp, _ := http.Get(url)
	defer resp.Body.Close()

	body, _ := ioutil.ReadAll(resp.Body)

	w.Header().Set("Content-Type", "application/json")
	w.Write(body)
}