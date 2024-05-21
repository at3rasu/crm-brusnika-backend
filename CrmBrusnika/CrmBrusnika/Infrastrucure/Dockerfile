FROM ubuntu:latest

RUN apt-get update && \
    apt-get install postgresql-client --yes

COPY pg-version.sh pg-version.sh

RUN chmod +x pg-version.sh

ENTRYPOINT ["/pg-version.sh"]
