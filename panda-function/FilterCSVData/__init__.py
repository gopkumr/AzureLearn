import logging

import azure.functions as func
import pandas as pd
import sys


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    try:
         req_body = req.get_body().decode('utf-8')
         from io import StringIO
         csvData = StringIO(req_body)
         df = pd.read_csv(csvData, sep=",")
         startCondition=df.valid_start > 1430406000
         instantCondition=df.instantaneous == False
         condition=startCondition & instantCondition
         series=df[condition]
    except ValueError:
         pass
    if req_body:
        return func.HttpResponse(f"{series}")
