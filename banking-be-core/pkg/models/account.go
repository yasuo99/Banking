package models

import "time"

type Account struct {
	AccountNo          string        `gorm:"primaryKey;column:accountNo"`
	AccountNickname    string        `gorm:"column:accountNickname"`
	Created_at         time.Time     `gorm:"default:current_timestamp"`
	Status             string        `gorm:"column:status"`
	BelongToCustomer   int32         `gorm:"column:belongToCustomer"`
	CreditTransactions []Transaction `gorm:"foreignKey:toAccount"`
	DebitTransactions  []Transaction `gorm:"foreignKey:fromAccount"`
}
