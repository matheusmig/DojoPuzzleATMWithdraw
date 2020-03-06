# Welcome to DojoPuzzle ATM Withdraw solution!

This main aim of this project is solving the ATM Withdraw Puzzle [(described here)](http://dojopuzzles.com/problemas/exibe/caixa-eletronico/), at same time it's implemented following principles from Clean Architecture. It use cases as central organizing structure. Built with small components that are developed and tested in isolation.

The solution architecture is basically splitted in two parts:
### Domain
This project holds the Entities, Value Objects and the Services which describe the Domain.

### Application
This project contains the Application Use Cases which orchestrate the high level business rules. It exposes Boundaries Interfaces which are used by the Api.

# How To run
Execute the following command to run locally the application:
```dotnet run --project ./src/WebApi/```

# Tests
Execute the following command to run the tests:
```dotnet test ./tests/UnitTests/```

# Invoking Endpoint
Once the WebApi is running, the endpoint could be invoked by the following cURL command:
```curl -X POST "https://localhost:5001/api/ATMTransaction" -H "Content-Type: application/json" -d "{"value":100}"```

Change value parameter to the desired withdraw money value.
