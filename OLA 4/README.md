# OLA 4 Systems Integration

Refactoring monolith to services.

Monolith: TrailerMonolith folder

Services: TrailerServices folder

## Domain

I have created three different services one for payment, one for rental and one for the trailers. They communicate with each other through api's.

Payment service handles the payment of late fees and insurance fees.

Trailer service handles the status of trailers if they available or not.

Rental service handles the rental of the trailers and calls the payment when it needs to process a payment and the trailer api when it needs to change the status of a trailer.