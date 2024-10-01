# OLA 3 Systems Integration

Domain Driven Design

Trailer Rental System

Event Storming:
Is a method used to model complex business processes used in Domain Driven Design. I have created six different diagrams which are the different steps in the event storming process.

Diagram order: Event sharing, event sequence, commands and actors, policies, external systems and read models, aggregates and bounded context.

# Event sharing
Event sharing involves finding all the domain events that occur in the system. This step does not consider how the events might interact with each other or the sequence.

# Event sequence
In this step you place all the domain events in chronological order. 

# Commands and actors
Commands represent the user that trigger domain events. A command might be "Place Order" which could trigger an "Order Placed" event.

Actors are the individuals or systems that issue commands. A customer might place an order or an automated system could process a payment.

# Policies
Policies are the business rules or conditions that govern how and when certain actions take place. In the trailer rental system this might be the rule that long-term rentals need to be booked on the website.

# External systems and read models
Third-party systems or services that the system interacts with like payment gateways or a location service.

Read models represent the queries used to display data to users.

# Aggregates and bounded contexts
Aggregates are the clusters of domain objects that are related like events with a commmon noun like "Search Trailers" and "Update Trailer Status".
 
Bounded contexts separates different parts of the system into smaller more manageable domains.

Video: https://youtu.be/JVpeRQQliMQ