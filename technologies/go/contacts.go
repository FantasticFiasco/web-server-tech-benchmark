package main

import (
	"database/sql"
	"encoding/json"
	"fmt"
	"github.com/julienschmidt/httprouter"
	_ "github.com/lib/pq"
	"net/http"
	"os"
)

var databaseHost = os.Getenv("Contacts:DatabaseHost")
var databaseName = os.Getenv("Contacts:DatabaseName")
var databaseUsername = os.Getenv("Contacts:DatabaseUsername")
var databasePassword = os.Getenv("Contacts:DatabasePassword")

var connectionString = fmt.Sprintf("host=%s dbname=%s user=%s password=%s",
	databaseHost,
	databaseName,
	databaseUsername,
	databasePassword)

var db, _ = sql.Open("postgres", connectionString)

func CreateContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	var contact Contact
	json.NewDecoder(r.Body).Decode(&contact)

	db.QueryRow("INSERT INTO contact (firstName, surname) VALUES ($1, $2) RETURNING id", contact.FirstName, contact.Surname).
		Scan(&contact.Id)

	w.Header().Set("Location", fmt.Sprintf("http://%s/contacts/%d", r.Host, contact.Id))
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(contact)
}

func GetContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	contact := Contact {}

	db.QueryRow("SELECT * FROM contact WHERE Id = $1", ps.ByName("id")).
		Scan(&contact.Id, &contact.FirstName, &contact.Surname)

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(contact)
}

func GetContacts(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	rows, _ := db.Query("SELECT * FROM contact")
	defer rows.Close()

	contacts := make([]Contact, 0)

	for rows.Next() {
		contact := Contact {}
		rows.Scan(&contact.Id, &contact.FirstName, &contact.Surname)
		contacts = append(contacts, contact)
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(contacts)
}

func DeleteContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	db.Exec("DELETE FROM contact WHERE Id = $1", ps.ByName("id"))

	w.WriteHeader(http.StatusNoContent)
}

type Contact struct {
	Id		int	`json:"id"`
	FirstName	string	`json:"firstName"`
	Surname		string	`json:"surname"`
}