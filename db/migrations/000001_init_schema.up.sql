CREATE TABLE "accounts" (
  "accountNo" varchar(15) PRIMARY KEY,
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

CREATE TABLE "transactions" (
  "id" integer PRIMARY KEY,
  "fromAccount" varchar(15),
  "toAccount" varchar(15),
  "amount" float,
  "fee" float,
  "created_at" timestamp
);

ALTER TABLE "account_in_histories" ADD FOREIGN KEY ("accountNo") REFERENCES "accounts" ("accountNo");

ALTER TABLE "account_out_histories" ADD FOREIGN KEY ("accountNo") REFERENCES "accounts" ("accountNo");

ALTER TABLE "accounts" ADD FOREIGN KEY ("belongToCustomer") REFERENCES "customers" ("id");

ALTER TABLE "transactions" ADD FOREIGN KEY ("fromAccount") REFERENCES "accounts" ("accountNo");

ALTER TABLE "transactions" ADD FOREIGN KEY ("toAccount") REFERENCES "accounts" ("accountNo");
