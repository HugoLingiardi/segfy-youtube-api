## Projeto segfy-youtube-api

Construa uma nova solução restful, utilizando no backend e no front os frameworks de sua preferência, a qual deverá conectar na API do YouTube e disponibilizar as seguintes funcionalidades:
- Botão para pesquisar canal/video;
- Listar os canais/videos encontrados e salvos no banco;
- Visualizar os detalhes de cada canal/video.

Alguns requisitos:
- Deve ser uma aplicação totalmente nova;
- A solução deve estar em um repositório público do GitHub;
- A aplicação deve armazenar as informações encontradas;
- Utilizar MongoDB, MySQL ou Postgres;
- O deploy deve ser realizado, preferencialmente na AWS;
- A aplicação precisa ter testes automatizados.

Quando terminar, faça um Pull Request neste repo e avise-nos por email.

## Links para acessar (quebrados já né)

- App - http://segfy-youtube-app.s3-website-us-east-1.amazonaws.com
- WebApi - http://segfyyoutubeapi-env.eba-u4hcnqhu.us-east-1.elasticbeanstalk.com/api/
- MongoDb - mongodb+srv://segfy:26KEFxj8afCWTuw@cluster0-l5iep.gcp.mongodb.net/Segfy-Youtube?authSource=admin&replicaSet=Cluster0-shard-0&w=majority&readPreference=primary&appname=MongoDB%20Compass&retryWrites=true&ssl=true

## Tecnologias

Projeto criado com as seguintes tecnologias:

- Asp.net Core 3.1 - WebApi do Youtube
- Angular 9.1.12 - Front-end do App
- MongoDb Compass - Armazenamento dos dados


## Testes automatizados

Criei um projeto na solução da API para realizar testes nos repositório e providers, o nome do projeto é Segfy.Youtube.Tests.

## Estruturas

Estrutura dos dados
		
	videos
		videoId
		videoTitle
		videoDescription
		channelTitle
		thumbnailUrl
		createdAt
		
	channels
		channelId
		channelTitle
		channelDescription
		thumbnailUrl
		createdAt

Provider para consultar na API do Youtube

	GetVideos 
	GetChannels

Para inserção de dados

	- Interface para repositório base
	
		- Retorna videos (filtro)
		- Retorna canais (filtro)
		
		- Retorna qtde videos
		- Retorna qtde canais		
		
		- Grava video (video)
		- Grava canal (canal)
		
		- Deleta video (videoId)
		- Deleta canal (canalId)
		
		- Retorna video (videoId)
		- Retorna canal (canalId)
				

Para retorno dos dados

	- API
	
		- Retorna vídeos do youtube com base no texto informado		
		- GET api/youtube/videos/{queryParams}
		- GET api/youtube/channels/{queryParams}
				
		- Retorna vídeos do youtube salvos na base de dados
		- GET api/youryoutube/videos/{queryParams}
		- GET api/youryoutube/channels/{queryParams}
		
		- GET api/youryoutube/video/{videoId}
		- GET api/youryoutube/channel/{channelId}		
		
		- Grava e deleta os vídeos e canais salvos na base de dados
		- POST api/youryoutube/videos/ {body video)
		- POST api/youryoutube/channels/ {body channel}		
		- DELETE api/youryoutube/videos/{videoId)
		- DELETE api/youryoutube/channels/{channelId}
