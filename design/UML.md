<details> 
<summary></summary>
custom_health_uml
@startuml;
actor User;
participant "Health service" as A;

User -> A: Health request;
activate A;

A -> User: Health response;
deactivate A;

@enduml
custom_health_uml
</details>

<details> 
<summary></summary>
custom_echo_uml
@startuml;
actor User;
participant "Echo service" as A;

User -> A: Echo request;
activate A;

A -> User: Echo response;
deactivate A;

@enduml
custom_echo_uml
</details>

<details> 
<summary></summary>
custom_relay_uml
@startuml;
actor User;
participant "Relay service" as A;
participant "Key/Value service" as B;

User -> A: Relay request;
activate A;

A -> B: Key/Value request;
activate B;

B -> A: Key/Value response;
deactivate B;

A -> User: Relay response;
deactivate A;

@enduml
custom_relay_uml
</details>

<details> 
<summary></summary>
custom_contacts_uml
@startuml;
actor User;
participant "Contacts service" as A;
participant "Database" as B;

User -> A: Create contact request;
activate A;

A -> B: SQL command;
activate B;

B -> A;
deactivate B;

A -> User: Create contact response;
deactivate A;

User -> A: Get contact request;
activate A;

A -> B: SQL query;
activate B;

B -> A;
deactivate B;

A -> User: Get contact response;
deactivate A;

User -> A: Get contacts request;
activate A;

A -> B: SQL query;
activate B;

B -> A;
deactivate B;

A -> User: Get contacts response;
deactivate A;

User -> A: Remove contact request;
activate A;

A -> B: SQL command;
activate B;

B -> A;
deactivate B;

A -> User: Remove contact response;
deactivate A;

@enduml
custom_contacts_uml
</details>