# Waillet API

A crypto wallet management API built with .NET 10

## Features

- User registration and authentication
- JWT token-based security
- Password hashing using PBKDF2 with salt
- Account management
- Money transfer between accounts
- Exchanged rate retrieval

## API Endpoints

### User Management

- `POST /api/user/register` - Register a new user
- `POST /api/user/login` - Authenticate and receive JWT token

#### Accounts
- `POST /api/accounts` \- Vytvořit nový účet. 


### Transactions
- `POST /api/transactions/exchange` - Převést peníze mezi účty dle aktuálního směnného kurzu.


