/*Set Identity_Insert Categorias ON;

Insert Into Categorias (CategoriaID, tipo)
Values ('1','Frutos');

Insert Into Categorias (CategoriaID, tipo)
Values ('2', 'Flores');

Insert Into Categorias (CategoriaID, tipo)
Values ('3', 'Legumes');

Insert Into Categorias (CategoriaID, tipo)
Values ('4', 'Ervas Aromáticas');*/

Set Identity_Insert Categorias OFF;

Set Identity_Insert Artigos ON;

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('1', 'Framboeseira', 'Rubus idaeus', '1', 'A framboeseira ou framboeseiro é uma planta arbustiva, com cerca de 40 a 60cm de altura, que crescia originalmente, em locais pedregosos e montanhosos e em terrenos graníticos.', 
'Fevereiro', 'Março', '950', '4', '3', '3','4','1');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('2', 'Groselheira', 'Grosis icaleus', '1', 'Arbusto de Frutos Vermelhos Comestíveis, pronto a plantar, com raiz e terraço, acondicionado em embalagem especial (Saco/Blister).', 
'Fevereiro', 'Março', '950', '4', '3', '3','5','1');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('3', 'Melancia', 'Cucurbitaceae', '1', 'Espécie originária das regiões secas de África tendo um centro de diversificação no sul da Ásia. A domesticação da Melancia ocorreu na África Central onde é cultivada á mais de 5000 anos.', 
'Fevereiro', 'Março', '20', '4', '3', '3','1.5','1');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('4', 'Calendula', 'Calendula officialis', '1', 'Flore muito comum na zona do Algarve.', 
'Fevereiro', 'Março', '20', '4', '3', '3','1.5','2');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('5', 'Cosmos', 'Cosmos bipinnatus', '1', 'De grandes flores simples rosa vivo, vermelhos e brancos com olho amarelo.', 
'Fevereiro', 'Março', '10', '4', '3', '3','1.5','2');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('6', 'Cebola Morada Amposta', 'Allium cepa', '1', 'Produz bolbos grandes em forma de globo, cor avermelhada e polpa branca rosada.', 
'Fevereiro', 'Março', '20', '4', '3', '3','1','3');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('7', 'Cebola Ramata de Milão', 'Allium cepa', '1', 'A cebola, Allium cepa L., é uma das espécies hortícolas mais antigas, sendo cultivada á pelo menos 5000 anos. Teve origem no centro da Ásia, tendo sido dispersa para Ocidente, atingiu a Pérsia de onde se irradiou para a África e para todo o continente europeu, sendo depois trazida para as Américas, pelos seus primeiros colonizadores.', 
'Fevereiro', 'Março', '20', '4', '3', '3','1','3');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('8', 'Arruda de Calcada', 'Ruta graveoleons', '1', 'Erva muito usada a porta das casas. E para ser queimada para afastar bruxas.', 
'Fevereiro', 'Março', '10', '4', '3', '3','1.4','1');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('9', 'Erva de Gato', 'Nepeta cataria', '1', 'A erva de gato é um complemento indispensável para o gato doméstico ou de companhia.', 
'Fevereiro', 'Março', '10', '4', '3', '3','1.1','1');

Insert Into Artigos(ArtigoID, nome, nometecnico, disponibilidade, descricao, plantacaoComeca, plantacaoAcaba, peso, crescimento, luz, rega, preço, CategoriaFK)
Values ('10', 'Segurelha', 'Satureja hortensis', '1', 'Erva muito apaladada com um trave forte usada para tempero de saladas.', 
'Fevereiro', 'Março', '10', '4', '3', '3','1.3','1');