package handlers

import (
	"banking-be-core/app/pkg/models"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"

	"github.com/gorilla/mux"
)

func (h handler) GetAllAccount(w http.ResponseWriter, r *http.Request) {
	var accounts []models.Account

	if result := h.DB.Find(&accounts); result.Error != nil {
		fmt.Println(result.Error)
	}
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(accounts)
}

func (h handler) CreateAccount(w http.ResponseWriter, r *http.Request) {
	defer r.Body.Close()
	body, err := ioutil.ReadAll(r.Body)

	if err != nil {
		log.Fatal(err)
	}

	var account models.Account
	json.Unmarshal(body, &account)
	fmt.Println(account)
	if result := h.DB.Create(&account); result.Error != nil {
		w.Header().Add("Content-Type", "application/json")
		w.WriteHeader(http.StatusBadRequest)
		json.NewEncoder(w).Encode(result.Error)
		fmt.Println(result.Error)
		return
	}

	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode("Created")
}

func (h handler) EditAccount(w http.ResponseWriter, r *http.Request) {
	defer r.Body.Close()
	w.Header().Add("ContentType", "application/json")
	body, err := ioutil.ReadAll(r.Body)
	if err != nil {
		log.Fatal(err)
	}
	vars := mux.Vars(r)
	id, _ := vars["id"]

	fmt.Println(id)
	var account models.Account

	json.Unmarshal(body, &account)

	var accountDb models.Account
	if result := h.DB.First(&accountDb, id); result.Error != nil {
		w.WriteHeader(http.StatusNotFound)
		json.NewEncoder(w).Encode("Can't find account no " + id)
		return
	}
	accountDb.Status = account.Status
	accountDb.AccountNickname = account.AccountNickname

	if updateResult := h.DB.Updates(&accountDb); updateResult.Error != nil || updateResult.RowsAffected == 0 {
		w.WriteHeader(http.StatusBadRequest)
		json.NewEncoder(w).Encode("Can't update account no " + id)
		return
	}
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode("Updated")
}

func (h handler) DeleteAccount(w http.ResponseWriter, r *http.Request) {
	defer r.Body.Close()
	w.Header().Add("ContentType", "application/json")
	vars := mux.Vars(r)

	id, _ := vars["id"]

	fmt.Println(id)
	var account models.Account
	if result := h.DB.First(&account, id); result.Error != nil {
		w.WriteHeader(http.StatusNotFound)
		json.NewEncoder(w).Encode("Can't find account no " + id)
		return
	}

	if deleteResult := h.DB.Delete(&account); deleteResult.Error != nil || deleteResult.RowsAffected == 0 {
		w.WriteHeader(http.StatusInternalServerError)
		json.NewEncoder(w).Encode("Can't delete account " + id)
		return
	}
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode("deleted account" + id)
}
