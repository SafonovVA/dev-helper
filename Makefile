.PHONY: build
build:
	docker build -t safonovva/devhelper -f DevHelper/Dockerfile .

.PHONY: run
run:
	docker run -p 8080:80 --name devhelper safonovva/devhelper

.PHONY: stop
stop:
	docker stop devhelper
	docker rm devhelper