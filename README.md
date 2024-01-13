# Pixel Solution

Pixel Solution is composed by 3 main projects: Pixel.Events, Pixel.Api, Storage.Api. That provides the functionality to read image presentations on the client and log those occurences.

## Pixel.Events

Pixe.Events contains the events definitions that the Pixel.Api publishes. The events are published to a RabbitMq broker.

## Pixel.Api

Pixel.Api it's an Api that exposes the **GET track** endpoint and captures the request information to be further logged.

## Storage.Api

Storage.Api listens to track event occurences and stores that activity to a log.

### Running on Docker

On the root folder run the command:

```bash
docker-compose up
```

Then open the browser on http://localhost:9666/track.