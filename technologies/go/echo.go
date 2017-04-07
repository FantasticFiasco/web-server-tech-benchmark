package main

import (
	"fmt"
	"github.com/julienschmidt/httprouter"
	"net/http"
)

func Echo(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {
	text := ps.ByName("text")
	fmt.Fprintf(w, text)
}
