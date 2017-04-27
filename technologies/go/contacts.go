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

var db* sql.DB

func InitDb() {
	var databaseHost = os.Getenv("Contacts_DatabaseHost")
	var databaseName = os.Getenv("Contacts_DatabaseName")
	var databaseUsername = os.Getenv("Contacts_DatabaseUsername")
	var databasePassword = os.Getenv("Contacts_DatabasePassword")

	var connectionString = fmt.Sprintf("host=%s dbname=%s user=%s password=%s",
		databaseHost,
		databaseName,
		databaseUsername,
		databasePassword)
	
	db, _ = sql.Open("postgres", connectionString)
	db.SetMaxOpenConns(300)
}

func CreateContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	var contact Contact
	json.NewDecoder(r.Body).Decode(&contact)

	err := db.QueryRow("INSERT INTO contact (firstName, surname) VALUES ($1, $2) RETURNING id", contact.FirstName, contact.Surname).
		Scan(&contact.Id)

	checkErr(err)

	w.Header().Set("Location", fmt.Sprintf("http://%s/contacts/%d", r.Host, contact.Id))
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(contact)
}

func GetContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	contact := Contact {}

	err := db.QueryRow("SELECT * FROM contact WHERE Id = $1", ps.ByName("id")).
		Scan(&contact.Id, &contact.FirstName, &contact.Surname)

	checkErr(err)

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(contact)
}

func GetContacts(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	rows, err := db.Query("SELECT * FROM contact")
	defer rows.Close()
	checkErr(err)

	contacts := make([]Contact, 0)

	for rows.Next() {
		contact := Contact {}
		err = rows.Scan(&contact.Id, &contact.FirstName, &contact.Surname)

		checkErr(err)

		contacts = append(contacts, contact)
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(contacts)
}

func DeleteContact(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	_, err := db.Exec("DELETE FROM contact WHERE Id = $1", ps.ByName("id"))

	checkErr(err)

	w.WriteHeader(http.StatusNoContent)
}

func checkErr(err error) {
	if err != nil {
		panic(err)
	}
}

type Contact struct {
	Id		int	`json:"id"`
	FirstName	string	`json:"firstName"`
	Surname		string	`json:"surname"`
}