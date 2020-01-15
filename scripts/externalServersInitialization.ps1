docker run --name rabbitmq -d -p 5672:5672 -p 5673:5673 -p 15672:15672 --net=host --hostname rabbitmq rabbitmq:3-management
docker run -d -p 5672:5672 --net=host rabbitmq
docker run -d -p 27017-27019:27017-27019 --net=host mongo
