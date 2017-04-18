package main

import (
	"fmt"
	"github.com/julienschmidt/httprouter"
	"log"
	"net/http"
	"strings"
	"encoding/json"
)

func Health(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	fmt.Fprintf(w, "I'm fine, thank you")
}

func Store(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	key := ps.ByName("key")

	value := strings.Map(func(r rune) rune {
		return caesar(r, 18)
	}, key)

	keyValue := KeyValue {
		Value: value,
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(keyValue)
}

func main() {
	router := httprouter.New()
	router.GET("/store/:key", Store)
	router.GET("/health", Health)

	log.Fatal(http.ListenAndServe(":8080", router))
}
