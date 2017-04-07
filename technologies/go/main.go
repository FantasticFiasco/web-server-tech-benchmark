package main

import (
	"github.com/julienschmidt/httprouter"
	"log"
	"net/http"
)

func main() {
	router := httprouter.New()

	// Health
	router.GET("/health", Health)

	// Echo
	router.GET("/echo/:text", Echo)

	// Relay
	router.GET("/relay/:key", Relay)

	// Contacts
	router.POST("/contacts", CreateContact)
	router.GET("/contacts/:id", GetContact)
	router.GET("/contacts", GetContacts)
	router.DELETE("/contacts/:id", DeleteContact)

	log.Fatal(http.ListenAndServe(":8090", router))
}