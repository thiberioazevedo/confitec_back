--Criar um comando Select que traga os usuários (nome e email) agrupados por faixa etária (até 20 anos, de 20 até 50 anos e acima de 50 anos) cuja escolaridade seja igual a “Superior”.
select	ClassificacaoIdade, 
		count(*) Quantidade
from
(
	select	case when idade <= 20 then 'Até 20 anos' else 
				case when idade <= 50 then 'De 20 até 50 anos' 
					else 'Acima de 50 anos' 
				end 
			end	ClassificacaoIdade
	from
	(
		select		convert (int, convert( decimal,convert (varchar( 10), getdate(), 112)) /10000 - convert( decimal,convert (varchar( 10), Usuarios.DataNascimento , 112)) /10000 ) Idade

		from		Usuarios

		inner join	Escolaridade
			on		Escolaridade.Id = Usuarios.EscolaridadeId

		where		Escolaridade.Nome = 'Superior'
	) sq1
) sq2 
group by ClassificacaoIdade



