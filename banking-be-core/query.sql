--name: GetAccount :one
SELECT * from accounts
WHERE accountNo = $1 LIMIT 1;