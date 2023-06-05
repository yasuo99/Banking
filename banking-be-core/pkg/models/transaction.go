package models

import "time"

type Transaction struct {
	Id          int32     `gorm:"primaryKey;column:id"`
	FromAccount string    `gorm:"column:fromAccount"`
	ToAccount   string    `gorm:"column:toAccount"`
	Amount      float32   `gorm:"column:amount"`
	Fee         float32   `gorm:"column:fee"`
	CreatedAt   time.Time `gorm:"column:created_at"`
}
