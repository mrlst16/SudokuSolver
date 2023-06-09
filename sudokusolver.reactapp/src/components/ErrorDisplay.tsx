import { FC } from "react";
import { ApiErrors } from "../models/ApiErrors";

interface ApiErrorsProps{
    Errors: ApiErrors;
}

const ErrorDisplay : FC<ApiErrorsProps> = ({Errors}) => {
    if(Errors==undefined || Errors.Errors.length == 0 )
    return(
        <></>
    )
    else
    return(
        <div>
            <ul>
            {
                Errors.Errors.map(error=> 
                    <li>
                        {error.Message}
                    </li>
                )
            }
            </ul>
        </div>
    )
}
export default ErrorDisplay;