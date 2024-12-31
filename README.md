# License Plate Recognition API
A simple yet effective API for recognizing license plates in images. Built with ASP.NET Core, this application integrates with the PlateRecognizer API to provide accurate license plate detection and recognition.

## Features
* License Plate Detection: Recognize and extract license plate information from images.
* RESTful API: Provides a simple endpoint for seamless integration into other applications.
* Image Upload Support: Accepts image files via HTTP POST requests.
* Robust Error Handling: Gracefully handles invalid or missing file uploads.

## Prerequisites
* .NET Core SDK (8.0 or higher)
* PlateRecognizer API Key: Get your API key from [PlateRecognizer](https://platerecognizer.com/).

## API Overview
### Endpoint: Recognize License Plate
POST /api/PlateRecognition/recognizelicenseplate

* Request:
Upload an image file using form-data with the key file.

* Response:
JSON data containing license plate recognition results.

## Setup Instructions
[1] Clone Repository
git clone https://github.com/yourusername/license-plate-recognition.git
cd license-plate-recognition
[2] Set Up Your API Key
Add your PlateRecognizer API key to appsettings.json:
{
  "PlateRecognizer": {
    "ApiKey": "your_api_key_here"
  }
}
[3] Run the Application
dotnet run
[4] Test the API
Use a tool like Postman or curl to send a POST request to the endpoint:
curl -X POST -F "file=@path_to_your_image.jpg" http://localhost:5000/api/PlateRecognition/recognizelicenseplate

## License
This project is licensed under the [MIT License](https://www.mit.edu/~amini/LICENSE.md).
