package main

import (
	"fmt"
	"github.com/julienschmidt/httprouter"
	"net/http"
	"os"
	"encoding/json"
)

var relayServiceHostname = os.Getenv("Relay:KeyValueServiceHostname")
var relayServicePort = os.Getenv("Relay:KeyValueServicePort")

func Relay(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	key := ps.ByName("key")
	url := fmt.Sprintf("http://%s:%s/store/%s", relayServiceHostname, relayServicePort, key)

	resp, _ := http.Get(url)
	defer resp.Body.Close()

	var keyValue KeyValue
	json.NewDecoder(resp.Body).Decode(&keyValue)

	var keyValuePair = KeyValuePair {
		Key: key,
		Value: keyValue.Value,
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(keyValuePair)
}

type KeyValue struct {
	Value	string	`json:"value"`
}

type KeyValuePair struct {
	Key	string	`json:"key"`
	Value	string	`json:"value"`
}