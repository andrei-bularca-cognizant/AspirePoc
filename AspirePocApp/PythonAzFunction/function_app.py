import azure.functions as func
import logging

app = func.FunctionApp(http_auth_level=func.AuthLevel.FUNCTION)

@app.route(route="http_trigger")
def http_trigger(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    name = req.params.get('name')
    if not name:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            name = req_body.get('name')

    if name:
        logging.info(f"Hello, {name}. This HTTP triggered function executed successfully.")
        return func.HttpResponse(f"Hello, {name}. This HTTP triggered function executed successfully.")
    else:
        logging.info("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.");
        return func.HttpResponse(
             "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.",
             status_code=200
        )