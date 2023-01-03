#!/usr/bin/env sh
set -e
set -x

project="e2etest"

cd "$(dirname "${0}")/.."
export COMPOSE_HTTP_TIMEOUT=200
docker-compose -p "$project" build

mkdir -m 777 reports

docker-compose -p "$project" up -d ea_api ea_webapp db ea_test node-docker selenium-hub
docker-compose -p "$project" up --no-deps ea_test


exit_code=$(docker inspect ea_test -f '{{ .State.ExitCode }}')

if [ $exit_code -eq 0 ]; then
    exit $exit_code
else
    echo "Test failed"
fi 

docker cp ea_test:/src/TestBdd/LivingDoc.html ./reports
echo "Specflow living doc reports is copied to ./reports"
ls -l ./reports


