# WebApi
Essa Api simula a execução de um job demorado que irá gerar um erro de timeout nos clientes. Esse erro será tratado para parar a execução do job quando ocorrer.

# Simulação
Utilize o software [Postman](https://www.postman.com/downloads/) para simular o cenário. Configure o Postman para ter uma timeout de 10 segundos na requisição e em seguinda execute a requisição ao endpoint `api/star-wars`.
Quando o Postman receber o erro de timeout, poderemos ver que a execução da aplicação foi interrompida. Observe o console da execução da aplicação para visualizar os detalhes.