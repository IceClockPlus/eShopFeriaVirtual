# Feria Virtual API

- [Feria Virtual API](#feria-virtual-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST{{host}}/auth/register
```
#### Register Request
```json
{
    "firstName": "Alex",
    "lastName" : "Blackwood",
    "email": "alexBlkwood@email.com",
    "password": "WoodTheDark_235"
}
```

#### Register Response
```js
200 OK
```

```json
{
    "id": "153"
    "firstName": "Alex",
    "lastName" : "Blackwood",
    "email": "alexBlkwood@email.com",
    "token": "eyJhb..z9dqcnXoY"
}
```

### Login
 
