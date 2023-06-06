import "../styles/Puzzle.css"
import { FC } from "react";

interface PuzzleProps{
    Grid : number[][]
}

const Puzzle : FC<PuzzleProps> = ({Grid}) => {
    return(
        <>
            <table className="puzzle">
                { 
                    Grid.map((x)=>
                    <tr>
                        {x.map(v=> <td>{v}</td>)}
                    </tr>
                    )
                }
            </table>    
        </>
    )
}

export default Puzzle