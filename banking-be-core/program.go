package main

import (
	// "banking-be-core/app/pkg/db"
	// "banking-be-core/app/pkg/handlers"
	"log"
	// "net/http"
	// "github.com/gorilla/mux"
)

func main() {
	// DB := db.Init()
	// h := handlers.New(DB)
	// router := mux.NewRouter()

	test := make(chan int, 3)
	test <- 500
	test <- 300
	test <- 200
	value := <-test
	log.Println(value)
	value = <-test
	log.Println(value)
	value = <-test
	log.Println(value)
	// router.HandleFunc("/accounts", h.GetAllAccount).Methods(http.MethodGet)
	// router.HandleFunc("/accounts", h.CreateAccount).Methods(http.MethodPost)
	// router.HandleFunc("/accounts/{id}", h.EditAccount).Methods(http.MethodPut)
	// router.HandleFunc("/accounts/{id}", h.DeleteAccount).Methods(http.MethodDelete)

	// log.Println("API is running at port 8080!")
	// err := http.ListenAndServe(":8080", router)
	// if err != nil {
	// 	log.Println("Start failed, port 8080 is already used")
	// }
}
