﻿$(document).ready(function () {

            var primeiro_peso_jq = @ViewBag.primeiro_peso;
            var ultimo_peso_jq = @ViewBag.ultimo_peso;
            var primeiro_preco_jq = @ViewBag.primeiro_preco;
            var ultimo_preco_jq = @ViewBag.ultimo_preco;
            var primeira_rega_jq = @ViewBag.primeira_rega;
            var ultima_rega_jq = @ViewBag.ultima_rega;
            var primeira_luz_jq = @ViewBag.primeira_luz;
            var ultima_luz_jq = @ViewBag.ultima_luz;
            var primeiro_crescimento_jq = @ViewBag.primeiro_crescimento;
            var ultimo_crescimento_jq = @ViewBag.ultimo_crescimento;
            
            var luz_jq = ["Sombra-Total", "Sombra-Parcial", "Meia-Sombra", "Meio-Sol", "Sol"];

            var crescimento_jq = ["Lento", "Moderado", "Normal", "Acelarado", "Rápido"];

            var rega_jq = ["Seca", "Quase-Seca", "Humido", "Molhado", "Encharcado"];

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

            // Slider para selecionar a quantidade de água necessária na rega
            //
            $("#slider-rega").slider({
                range: true,
                min: primeira_rega_jq,
                max: ultima_rega_jq,
                step: 1,
                values: [primeira_rega_jq, ultima_rega_jq],
                slide: function (event, ui) {
                    $("#rega-div").text("Terra de " + rega_jq[ui.values[0]] + " até " + rega_jq[ui.values[1]]);
                    $("#rega-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para quantidade de água necessária na rega
            // Tanto na label como no input
            //
            $("#rega-div").text("Terra de " + rega_jq[$("#slider-rega").slider("values", 0)] +
              " até " + rega_jq[$("#slider-rega").slider("values", 1)]);
            $("#rega-in").val($("#slider-rega").slider("values", 0) + " " + $("#slider-rega").slider("values", 1));

            // Slider para selecionar a gama de luzes a serem utilizadas
            //
            $("#slider-luz").slider({
                range: true,
                min: primeira_luz_jq,
                max: ultima_luz_jq,
                step: 1,
                values: [primeira_luz_jq, ultima_luz_jq],
                slide: function (event, ui) {
                    $("#luz-div").text("Luminosidade de " + luz_jq[ui.values[0]] + " até " + luz_jq[ui.values[1]]);
                    $("#luz-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para as gamas de luz
            //
            $("#luz-div").text("Luminusidade de " + luz_jq[$("#slider-luz").slider("values", 0)] +
              " até " + luz_jq[$("#slider-luz").slider("values", 1)]);
            $("#luz-in").val($("#slider-luz").slider("values", 0) + " " + $("#slider-luz").slider("values", 1));

            // Slider para selecionar a gama de velocidades de crescimento a pesquisar
            //
            $("#slider-crescimento").slider({
                range: true,
                min: primeiro_crescimento_jq,
                max: ultimo_crescimento_jq,
                step: 1,
                values: [primeiro_crescimento_jq, ultimo_crescimento_jq],
                slide: function (event, ui) {
                    $("#crescimento-div").text("crescimento de " + crescimento_jq[ui.values[0]] + " até " + crescimento_jq[ui.values[1]]);
                    $("#crescimento-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para velocidade de crescimento
            //
            $("#crescimento-div").text("crescimento de " + crescimento_jq[$("#slider-crescimento").slider("values", 0)] +
              " até " + crescimento_jq[$("#slider-crescimento").slider("values", 1)]);
            $("#crescimento-in").val($("#slider-crescimento").slider("values", 0) + " " + $("#slider-luz").slider("values", 1));

            // Slider para selecionar a gama de pesos a pesquisar
            //
            $("#slider-peso").slider({
                range: true,
                min: primeiro_peso_jq,
                max: ultimo_peso_jq,
                step: ((ultimo_peso_jq -  primeiro_peso_jq) / 50),
                values: [primeiro_peso_jq, ultimo_peso_jq],
                slide: function (event, ui) {
                    $("#peso-div").text("Peso de " + ui.values[0] + " gramas até " + ui.values[1] + " gramas");
                    $("#peso-in").val(ui.values[0] + " " + ui.values[1]);
            }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para peso
            //
            $("#peso-div").text("Peso de " + $("#slider-peso").slider("values", 0) +
              " gramas até " + $("#slider-peso").slider("values", 1) + " gramas");
            $("#peso-in").val($("#slider-peso").slider("values", 0) + " " + $("#slider-peso").slider("values", 1));

            // Slider para selecionar a gama de precos a pesquisar
            //
            $("#slider-preco").slider({
                range: true,
                min: primeiro_preco_jq,
                max: ultimo_preco_jq,
                step: ((ultimo_preco_jq - primeiro_preco_jq) / 50),
                values: [primeiro_preco_jq, ultimo_preco_jq],
                slide: function (event, ui) {
                    $("#preco-div").text("de €" + ui.values[0] + " até €" + ui.values[1]);
                    $("#peso-in").val(ui.values[0] + " " + ui.values[1]);
                }
            });

            // Funcão para atribuir um valor inicial ao valor a ser escolhido para preco
            //
            $("#preco-div").text("de €" + $("#slider-preco").slider("values", 0) +
              " até €" + $("#slider-preco").slider("values", 1));
            $("#preco-in").val($("#slider-preco").slider("values", 0) + " " + $("#slider-preco").slider("values", 1));
        });