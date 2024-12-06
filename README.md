"# plate-recognizer"
License Plate Recognition API
This repository contains a simple ASP.NET Core Web API for recognizing license plates from uploaded images. The API uses the Plate Recognizer API to process images and return recognition results.

Features
Upload an image file containing a vehicle license plate.
Process the image using the Plate Recognizer API.
Return license plate recognition results in JSON format.
Getting Started
Prerequisites
.NET SDK: Install the .NET SDK version 6.0 or later.
API Key: Obtain an API key from Plate Recognizer.
Installation
Clone the repository:

git clone https://github.com/your-repo/license-plate-recognition-api.git
cd license-plate-recognition-api
Update the API key in Program.cs:

builder.Services.AddSingleton(sp => new PlateRecognizerService(
sp.GetRequiredService<HttpClient>(),
"your-api-key-here"
));
Restore dependencies:

dotnet restore
Build the application:

dotnet build
Running the Application
Run the API locally:

dotnet run
The API will be available at https://localhost:5001 or http://localhost:5000.

API Endpoints
Recognize License Plate
Endpoint: POST /api/platerecognition/recognizelicenseplate
Description: Upload an image file to recognize the license plate.

Request
Headers:
Content-Type: multipart/form-data
Body:
file: The image file to be uploaded (JPEG format recommended).
Example (Using cURL):
curl -X POST "https://localhost:5001/api/platerecognition/recognizelicenseplate" \
-H "Content-Type: multipart/form-data" \
-F "file=@path-to-your-image.jpg"
Response
On success, the endpoint returns the recognition results from the Plate Recognizer API.

Project Structure
PlateRecognitionController
Defines the POST endpoint for license plate recognition.
Accepts an image file, processes it using the PlateRecognizerService, and returns the result.
PlateRecognizerService
Communicates with the Plate Recognizer API.
Handles image uploads and sends recognition requests.
Program.cs
Configures the application services and middleware.
Registers PlateRecognizerService with dependency injection.
Dependencies
ASP.NET Core: Web API framework.
HttpClient: Used for making HTTP requests to the Plate Recognizer API.
Swagger/OpenAPI: Automatically generates API documentation.
Running with Swagger UI
Swagger is pre-configured for this project. After running the application, navigate to:

https://localhost:5001/swagger
You can test the API directly from the Swagger UI.

Contributing
Contributions are welcome! Please fork this repository, create a feature branch, and submit a pull request.
