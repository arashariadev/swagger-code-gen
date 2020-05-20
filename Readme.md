Example of fast integration asp.net core with angular 2+ via OpenAPI

There is several codegens for swagger [swagger-codegen](https://github.com/swagger-api/swagger-codegen), [autorest](https://github.com/Azure/autorest), etc.
Main reason why I use swagger-codegen, when i try autorest last time it didn't support openAPI 3.0.
For now you can use whatever you want. Autorest more comfortable for me becouse it doesn't required java

## Generate angular clients via swagger-codegen
Run in terminal:

`swagger-codegen generate -i http://localhost:5000/swagger/v1/swagger.json -l typescript-angular -o ./angular-api-client`

### TODO:

1. Add one more controllers
2. Add Async controller
3. Add angular project to display codegen works from end to end
4. Add Example with autorest
