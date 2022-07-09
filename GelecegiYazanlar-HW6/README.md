## The comparison between the lifetimes of three types of Dependency Injection.

### First Request:
![image](https://user-images.githubusercontent.com/74410797/161456591-60905cf9-acd7-4b00-9604-b1531dd12078.png)

### Second Request:
![image](https://user-images.githubusercontent.com/74410797/161456602-29c18651-b15c-4e09-bf49-fb71a57ce49a.png)

## Results:
- In Singleton, the same instance is used regardless of requests. 
- In Scoped, the same instance is used until a new request.
- In Transient, a new instance is created for each request as well as for each object.
