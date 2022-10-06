# Write modern PHP without framework

This code is part of the article posted on https://medium.com/@dhgouveia/d244d8ca2b50


https://dev.to/ajayyadav/composer-update-vs-composer-install-2na1
# composer install
- https://getcomposer.org/download/
- composer install
- composer update

# to run server
php -S localhost:8000

# to test logs
```console
//New Lines
use App\Lib\Logger;
Logger::enableSystemLogs();
$logger = Logger::getInstance();
$logger->info('Hello World');
```
# get post 1
curl -X GET http://localhost:8000/post/1

# create a post
curl -X POST \
 http://localhost:8000/post \
 -H 'Content-Type: application/json' \
 -d '{"title": "Hello World", "body": "My Content"}'


# adding testing
- composer require --dev peridot-php/peridot
- composer require --dev squizlabs/php_codesniffer
- composer require --dev peridot-php/leo
- composer require --dev eloquent/phony-peridot

leo provides expect functionality and phony-peridot provides stubs functionality that is very handy to check if a function was called

# to run the tests
composer run-script test

