#  Склад автозапчастин.
##  Функціональні вимоги:
###  Склад:
####  Типовий представник вантажник:
-  Повинен мати можливість вести моніторинг усіх наявних на складі автозапчастин (GET) та моніторинг конкретної запчастини (GET by ID);
###  Локальний склад:
####  Типовий представник вантажник:
-  Повинен мати можливість вести моніторинг усіх наявних на складі автозапчастин (GET) та моніторинг конкретної запчастини (GET by ID);
-  Повинен мати можливість додавати автозапчастини у базу даних складу (POST);
-  Повинен мати можливість вносити корективи у існуючі записи складу (PUT та PATCH);
-  Повинен мати можливість видаляти конкретні записи складу (DELETE);
##  Методи
###  Опис складів:
####  GET:
Url: /api/v1/stores
<br/>Вхідна модель: {}
<br/>Вихідна модель:
<br/>{
<br/>id : int, min=1, max=65535
<br/>address: string, min=1, max=255
<br/>}
<br/>Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  GET(id):
Url: /api/v1/stores/{id}
<br/>Вхідна модель: {id : int, min=1, max=65535}
<br/>Вихідна модель:
<br/>{
<br/>id : int, min=1, max=65535
<br/>address: string, min=1, max=255
<br/>}}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  POST:
Url: /api/v1/stores
<br/>Вхідна модель: 
<br/>{
<br/>id : int, min=1, max=65535
<br/>address: string, min=1, max=255
<br/>}
<br/>Вихідна модель:
<br/>{
<br/>id: int, min=1, max=65535
<br/>status: string, min=1, max=255
<br/>}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  PUT(id):
Url: /api/v1/stores/{id}
<br/>Вхідна модель: 
<br/>{
<br/>id : int, min=1, max=65535
<br/>address: string, min=1, max=255
<br/>}
<br/>Вихідна модель:
<br/>{
<br/>id: int min=1, max=65535
<br/>status: string, min=1, max=255
<br/>}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
#### DELETE(id) 
Url: /api/v1/stores/{id}
<br/>Вхідна модель: 
<br/>{ id: int, min=1, max=65535}
<br/>Вихідна модель:
<br/>{ isDeleted: string, min=1, max=255}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)

###  Опис автозапчастин:
####  GET:
Url: /api/v1/shops/{storeId}/parts
<br/>Вхідна модель: {}
<br/>Вихідна модель:
<br/>{
<br/>id : int, min=1, max=65535
<br/>name: string, min=1, max=255
<br/>manufacturer: string, min=1, max=255
<br/>price: float, min=0, max=1000000
<br/>category: string, min=1, max=255
<br/>description: string, min=1, max=255
<br/>count: int, min=0, max=(2^32-1)
<br/>}
<br/>Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  GET(id):
Url: /api/v1/shops/{storeId}/parts/{id}
<br/>Вхідна модель: {id : int, min=1, max=65535}
<br/>Вихідна модель:
<br/>{
<br/>id : int, min=1, max=65535
<br/>name: string, min=1, max=255
<br/>manufacturer: string, min=1, max=255
<br/>price: float, min=0, max=1000000
<br/>category: string, min=1, max=255
<br/>description: string, min=1, max=255
<br/>count: int, min=0, max=(2^32-1)
<br/>}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  POST:
Url: /api/v1/shops/{storeId}/parts
<br/>Вхідна модель: 
<br/>{
<br/>id : int, min=1, max=65535
<br/>name: string, min=1, max=255
<br/>manufacturer: string, min=1, max=255
<br/>price: float, min=0, max=1000000
<br/>category: string, min=1, max=255
<br/>description: string, min=1, max=255
<br/>count: int, min=0, max=(2^32-1)
<br/>}
<br/>Вихідна модель:
<br/>{
<br/>id: int, min=1, max=65535
<br/>status: string, min=1, max=255
<br/>}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
####  PUT(id):
Url: /api/v1/shops/{storeId}/parts/{id}
<br/>Вхідна модель: 
<br/>{
<br/>id : int, min=1, max=65535
<br/>name: string, min=1, max=255
<br/>manufacturer: string, min=1, max=255
<br/>price: float, min=0, max=1000000
<br/>category: string, min=1, max=255
<br/>description: string, min=1, max=255
<br/>count: int, min=0, max=(2^32-1)
<br/>}
<br/>Вихідна модель:
<br/>{
<br/>id: int, min=1, max=65535
<br/>status: string, min=1, max=255
<br/>}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)
#### DELETE(id) 
Url: /api/v1/shops/{storeId}/parts/{id}
<br/>Вхідна модель: 
<br/>{ id: int, min=1, max=65535}
<br/>Вихідна модель:
<br/>{ isDeleted: string, min=1, max=255}
<br/>У разі виникненян помилки передавати Error (404)| BadRequest(404) | InternalServerError (500)

##  Нефункціональні вимоги:
-	Безпека та конфіденційність;
-	Надійність;
-	Відновлювальність;
-	Продуктивність (час виконання запитів не більше двох секунд);
-	Збереження даних;
-	Керування помилками.
