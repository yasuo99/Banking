package models

type Customer struct {
	Id       int32     `gorm:"primaryKey;column:id"`
	FullName string    `gorm:"column:fullname"`
	IdNo     string    `gorm:"column:idNo"`
	MobileNo string    `gorm:"column:mobileNo"`
	Accounts []Account `gorm:"foreignKey:belongToCustomer;references:Id"`
}
