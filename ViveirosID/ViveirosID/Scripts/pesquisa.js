$(document).ready(function () {

            var primeiro_Peso_jq = @ViewBag.primeiro_Peso;
            var ultimo_Peso_jq = @ViewBag.ultimo_Peso;
            var primeiro_Preco_jq = @ViewBag.primeiro_Preco;
            var ultimo_Preco_jq = @ViewBag.ultimo_Preco;
            var primeira_Rega_jq = @ViewBag.primeira_Rega;
            var Ultima_Rega_jq = @ViewBag.Ultima_Rega;
            var primeira_Luz_jq = @ViewBag.primeira_Luz;
            var Ultima_Luz_jq = @ViewBag.Ultima_Luz;
            var primeiro_Crescimento_jq = @ViewBag.primeiro_Crescimento;
            var ultimo_Crescimento_jq = @ViewBag.ultimo_Crescimento;
            
            var Luz_jq = ["Sombra-Total", "Sombra-Parcial", "Meia-Sombra", "Meio-Sol", "Sol"];

            var Crescimento_jq = ["Lento", "Moderado", "Normal", "Acelarado", "Rápido"];

            var Rega_jq = ["Seca", "Quase-Seca", "Humido", "Molhado", "Encharcado"];

            // Funcão que deve disparar com um click no elemento "file"
            //
            $(function(){
                alert("chourico");
                $("#file").click(function(){
                    var input = $("#file").value;
                    if (input.files && input.files[0]) {
                    
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#imgpreview').css('visibility', 'visible');
                            $('#imgpreview').attr('src', e.target.result);
                        }
                        reader.readAsDataURL(input.files[0]);
                    }
                });
            });

            // Slider para selecionar a quantidade de água necessária na Rega
            //
            $("#slider-Rega").slider({
                range: true,
                min: primeira_Rega_jq,
                max: Ultima_Rega_jq,
                step: 1,
                values: [primeira_Rega_jq, Ultima_Rega_jq],
                slide: function (event, ui) {
                    $("#Rega-div").text("Terra de " + Rega_jq[ui.values[0]] + " até " + Rega_jq[ui.values[1]]);
                    $("#Rega-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para quantidade de água necessária na Rega
            // Tanto na label como no input
            //
            $("#Rega-div").text("Terra de " + Rega_jq[$("#slider-Rega").slider("values", 0)] +
              " até " + Rega_jq[$("#slider-Rega").slider("values", 1)]);
            $("#Rega-in").val($("#slider-Rega").slider("values", 0) + " " + $("#slider-Rega").slider("values", 1));

            // Slider para selecionar a gama de Luzes a serem utilizadas
            //
            $("#slider-Luz").slider({
                range: true,
                min: primeira_Luz_jq,
                max: Ultima_Luz_jq,
                step: 1,
                values: [primeira_Luz_jq, Ultima_Luz_jq],
                slide: function (event, ui) {
                    $("#Luz-div").text("Luminosidade de " + Luz_jq[ui.values[0]] + " até " + Luz_jq[ui.values[1]]);
                    $("#Luz-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para as gamas de Luz
            //
            $("#Luz-div").text("Luminusidade de " + Luz_jq[$("#slider-Luz").slider("values", 0)] +
              " até " + Luz_jq[$("#slider-Luz").slider("values", 1)]);
            $("#Luz-in").val($("#slider-Luz").slider("values", 0) + " " + $("#slider-Luz").slider("values", 1));

            // Slider para selecionar a gama de velocidades de Crescimento a pesquisar
            //
            $("#slider-Crescimento").slider({
                range: true,
                min: primeiro_Crescimento_jq,
                max: ultimo_Crescimento_jq,
                step: 1,
                values: [primeiro_Crescimento_jq, ultimo_Crescimento_jq],
                slide: function (event, ui) {
                    $("#Crescimento-div").text("Crescimento de " + Crescimento_jq[ui.values[0]] + " até " + Crescimento_jq[ui.values[1]]);
                    $("#Crescimento-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para velocidade de Crescimento
            //
            $("#Crescimento-div").text("Crescimento de " + Crescimento_jq[$("#slider-Crescimento").slider("values", 0)] +
              " até " + Crescimento_jq[$("#slider-Crescimento").slider("values", 1)]);
            $("#Crescimento-in").val($("#slider-Crescimento").slider("values", 0) + " " + $("#slider-Luz").slider("values", 1));

            // Slider para selecionar a gama de Pesos a pesquisar
            //
            $("#slider-Peso").slider({
                range: true,
                min: primeiro_Peso_jq,
                max: ultimo_Peso_jq,
                step: ((ultimo_Peso_jq -  primeiro_Peso_jq) / 50),
                values: [primeiro_Peso_jq, ultimo_Peso_jq],
                slide: function (event, ui) {
                    $("#Peso-div").text("Peso de " + ui.values[0] + " gramas até " + ui.values[1] + " gramas");
                    $("#Peso-in").val(ui.values[0] + " " + ui.values[1]);
            }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para Peso
            //
            $("#Peso-div").text("Peso de " + $("#slider-Peso").slider("values", 0) +
              " gramas até " + $("#slider-Peso").slider("values", 1) + " gramas");
            $("#Peso-in").val($("#slider-Peso").slider("values", 0) + " " + $("#slider-Peso").slider("values", 1));

            // Slider para selecionar a gama de Precos a pesquisar
            //
            $("#slider-Preco").slider({
                range: true,
                min: primeiro_Preco_jq,
                max: ultimo_Preco_jq,
                step: ((ultimo_Preco_jq - primeiro_Preco_jq) / 50),
                values: [primeiro_Preco_jq, ultimo_Preco_jq],
                slide: function (event, ui) {
                    $("#Preco-div").text("de €" + ui.values[0] + " até €" + ui.values[1]);
                    $("#Peso-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para Preco
            //
            $("#Preco-div").text("de €" + $("#slider-Preco").slider("values", 0) +
              " até €" + $("#slider-Preco").slider("values", 1));
            $("#Preco-in").val($("#slider-Preco").slider("values", 0) + " " + $("#slider-Preco").slider("values", 1));
        });