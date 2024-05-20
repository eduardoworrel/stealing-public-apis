using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Playwright;

public static class browserExtensions
{
    public static async Task<IResult> LichessAsync(this IBrowser browser){
        // var content ="";
        try{

        var page = await browser.NewPageAsync();
            await page.GotoAsync("https://lichess.org/broadcast/2024-superbet-poland-rapid--blitz/blitz-round-8/RePro1Fx/vfaEZeSI");
            var scriptJavascript = @"
                async () => {

                    const url = 'https://lichess.org/study/RePro1Fx/vfaEZeSI'
                  
                    const r = await fetch(url, {
                        method: 'GET',
                        headers: {
                            'Accept': 'application/web.lichess+json',
                        },
                    });
                    return await r.text();
                }
            ";
            var content = await page.EvaluateAsync<string>(scriptJavascript);
            return Results.Text(content);
        }catch(Exception e){
            // throw e;
        }finally{
             await browser.CloseAsync();
        }
        return Results.BadRequest(";/");
    }
    public static async Task<IResult> ChessAsync(this IBrowser browser){
        // var content ="";
        try{

            //https://www.chess.com/events/2024-gct-superbet-poland-rapid-blitz/17/Wei_Yi-Praggnanandhaa_R
            //https://www.chess.com/events/v1/api/game/2024-gct-superbet-poland-rapid-blitz/17/Wei_Yi-Praggnanandhaa_R
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.chess.com/events/2024-gct-superbet-poland-rapid-blitz/17/Wei_Yi-Praggnanandhaa_R");
            var scriptJavascript = @"
                async () => {

                    const url = 'https://www.chess.com/events/v1/api/game/2024-gct-superbet-poland-rapid-blitz/17/Wei_Yi-Praggnanandhaa_R'
                    const body = {markerMoves: 0, markerAnalysis: 999999999}

                    const r = await fetch(url, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(body)
                    });
                    return await r.text();
                }
            ";
            var content = await page.EvaluateAsync<string>(scriptJavascript);
            return Results.Text(content);
        }catch(Exception e){
            // throw e;
        }finally{
             await browser.CloseAsync();
        }
        return Results.BadRequest(";/");
    }
    public static async Task<IResult> GupyAsync(this IBrowser browser){
        try{
            var page = await browser.NewPageAsync();
            var response = await page.GotoAsync("https://portal.api.gupy.io/api/v1/jobs?jobName=.net&limit=10&offset=10");
            if(response != null){
                var text = await response.JsonAsync();
                return Results.Ok(text);
            }
        }catch{

        }finally{
            await browser.CloseAsync();
        }
        return Results.BadRequest(";/");
    }
}