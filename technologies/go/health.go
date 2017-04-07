package main

import (
	"github.com/julienschmidt/httprouter"
	"net/http"	
)

func Health(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	w.WriteHeader(http.StatusNoContent)
}
