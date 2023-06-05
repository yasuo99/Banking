CREATE TABLE "accounts" (
  "id" integer PRIMARY KEY,
  "accountNo" varchar(15),
  "accountNickname" varchar(20),
  "accountBalance" float,
  "created_at" timestamp,
  "status" varchar,
  "belongToCustomer" integer
);

CREATE TABLE "account_in_histories" (
  "id" integer PRIMARY KEY,
  "accountNo" varchar(15),
  "amount" float,
  "created_at" timestamp
);

CREATE TABLE "account_out_histories" (
  "id" integer PRIMARY KEY,
  "accountNo" varchar(15),
  "amount" float
);

CREATE TABLE "customers" (
  "id" integer PRIMARY KEY,
  "fullname" varchar(50),
  "idNo" varchar(12),
  "mobileNo" varchar(11)
);

ALTER TABLE "account_in_histories" ADD FOREIGN KEY ("accountNo") REFERENCES "accounts" ("accountNo");

ALTER TABLE "account_out_histories" ADD FOREIGN KEY ("accountNo") REFERENCES "accounts" ("accountNo");

ALTER TABLE "accounts" ADD FOREIGN KEY ("belongToCustomer") REFERENCES "customers" ("id");
