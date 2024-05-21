#!/bin/bash

echo "$0: Start: $(date)"

echo "Viewing the PostgreSQL Server Version"

export PGPASSWORD='12344321'
psql -h rc1d-ltn9pg23vrnhsuzd.mdb.yandexcloud.net -p 6432 --set=sslmode=require -U user1 -d crm-brusnika -c 'select version();'

echo "$0: End: $(date)"
