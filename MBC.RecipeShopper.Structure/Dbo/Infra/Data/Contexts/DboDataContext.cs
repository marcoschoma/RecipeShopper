using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.ShoplistIngredient;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.Shoplist;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.Recipe;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.Ingredient;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.AmountType;
using System;
using System.Data.Common;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings;
using MBCTech.RecipeShopper.Shared.Infra.Data.Contexts;
using MBCTech.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Contexts
{
	public class DboDataContext : DataContext
	{
		private DbConnection _conn;
		
		public DboDataContext(IUnitOfWork uow)
		{
			_conn = uow.Connection;
			uow.AddContext(this);
			InitConfigurations();
		}

        public DbSet<ApoliceInfo> Apolice { get; set; }
		
		public DbSet<ApoliceAtuadorInfo> ApoliceAtuador { get; set; }
		
		public DbSet<ApoliceItemInfo> ApoliceItem { get; set; }
		
		public DbSet<BairroInfo> Bairro { get; set; }
		
		public DbSet<BairroFaixaCepInfo> BairroFaixaCep { get; set; }
		
		public DbSet<BancoInfo> Banco { get; set; }
		
		public DbSet<BancoAgendamentoInfo> BancoAgendamento { get; set; }
		
		public DbSet<BancoCarteiraInfo> BancoCarteira { get; set; }
		
		public DbSet<BancoEspecieInfo> BancoEspecie { get; set; }
		
		public DbSet<BancoInstrucaoInfo> BancoInstrucao { get; set; }
		
		public DbSet<BancoInstrucaoProtestoInfo> BancoInstrucaoProtesto { get; set; }
		
		public DbSet<BancoModalidadeInfo> BancoModalidade { get; set; }
		
		public DbSet<BancoOcorrenciaRejeicaoInfo> BancoOcorrenciaRejeicao { get; set; }
		
		public DbSet<BancoOcorrenciaRemessaInfo> BancoOcorrenciaRemessa { get; set; }
		
		public DbSet<BancoOcorrenciaRetornoInfo> BancoOcorrenciaRetorno { get; set; }
		
		public DbSet<BancoTipoMovimentoInfo> BancoTipoMovimento { get; set; }
		
		public DbSet<BorderoInfo> Bordero { get; set; }
		
		public DbSet<BorderoTituloDuplicataInfo> BorderoTituloDuplicata { get; set; }
		
		public DbSet<CentroCustoInfo> CentroCusto { get; set; }
		
		public DbSet<CfopInfo> Cfop { get; set; }
		
		public DbSet<CidadeInfo> Cidade { get; set; }
		
		public DbSet<CidadeFaixaCepInfo> CidadeFaixaCep { get; set; }
		
		public DbSet<CiotInfo> Ciot { get; set; }
		
		public DbSet<ClienteInfo> Cliente { get; set; }
		
		public DbSet<ClienteContaContabilInfo> ClienteContaContabil { get; set; }
		
		public DbSet<ClienteEdiInfo> ClienteEdi { get; set; }
		
		public DbSet<ClienteTmsInfo> ClienteTms { get; set; }
		
		public DbSet<ClienteWmsInfo> ClienteWms { get; set; }
		
		public DbSet<CodigoStatusInfo> CodigoStatus { get; set; }
		
		public DbSet<CondicaoFaturamentoInfo> CondicaoFaturamento { get; set; }
		
		public DbSet<CondicaoFaturamentoItemInfo> CondicaoFaturamentoItem { get; set; }
		
		public DbSet<ConexaoInfo> Conexao { get; set; }
		
		public DbSet<ConexaoClienteInfo> ConexaoCliente { get; set; }
		
		public DbSet<ConferenciaInfo> Conferencia { get; set; }
		
		public DbSet<ConferenciaUaInfo> ConferenciaUa { get; set; }
		
		public DbSet<ConferenciaUaItemInfo> ConferenciaUaItem { get; set; }
		
		public DbSet<ConfigInfo> Config { get; set; }
		
		public DbSet<ConfiguracaoInfo> Configuracao { get; set; }
		
		public DbSet<ContaContabilInfo> ContaContabil { get; set; }
		
		public DbSet<ContaCorrenteInfo> ContaCorrente { get; set; }
		
		public DbSet<ContaCorrenteCarteiraInfo> ContaCorrenteCarteira { get; set; }
		
		public DbSet<ContaCorrenteMovimentacaoInfo> ContaCorrenteMovimentacao { get; set; }
		
		public DbSet<ContaCorrenteMovimentacaoDuplicataInfo> ContaCorrenteMovimentacaoDuplicata { get; set; }
		
		public DbSet<ContratoInfo> Contrato { get; set; }
		
		public DbSet<CotacaoInfo> Cotacao { get; set; }
		
		public DbSet<CotacaoItemInfo> CotacaoItem { get; set; }
		
		public DbSet<DdaInfo> Dda { get; set; }
		
		public DbSet<DdaImagemInfo> DdaImagem { get; set; }
		
		public DbSet<DeParaInfo> DePara { get; set; }
		
		public DbSet<DocumentoInfo> Documento { get; set; }
		
		public DbSet<DocumentoColInfo> DocumentoCol { get; set; }
		
		public DbSet<DocumentoCteInfo> DocumentoCte { get; set; }
		
		public DbSet<DocumentoEletronicoInfo> DocumentoEletronico { get; set; }
		
		public DbSet<DocumentoEletronicoCstatusInfo> DocumentoEletronicoCstatus { get; set; }
		
		public DbSet<DocumentoEnderecoServicoInfo> DocumentoEnderecoServico { get; set; }
		
		public DbSet<DocumentoFaturarInfo> DocumentoFaturar { get; set; }
		
		public DbSet<DocumentoFinInfo> DocumentoFin { get; set; }
		
		public DbSet<DocumentoFreteInfo> DocumentoFrete { get; set; }
		
		public DbSet<DocumentoImpostoInfo> DocumentoImposto { get; set; }
		
		public DbSet<DocumentoItemInfo> DocumentoItem { get; set; }
		
		public DbSet<DocumentoNfeInfo> DocumentoNfe { get; set; }
		
		public DbSet<DocumentoNfeFreteInfo> DocumentoNfeFrete { get; set; }
		
		public DbSet<DocumentoObservacaoInfo> DocumentoObservacao { get; set; }
		
		public DbSet<DocumentoPedInfo> DocumentoPed { get; set; }
		
		public DbSet<DocumentoRegiaoInfo> DocumentoRegiao { get; set; }
		
		public DbSet<DocumentoRelacionadoInfo> DocumentoRelacionado { get; set; }
		
		public DbSet<DocumentoTmsInfo> DocumentoTms { get; set; }
		
		public DbSet<DocumentoTmsOcorrenciaInfo> DocumentoTmsOcorrencia { get; set; }
		
		public DbSet<DocumentoTmsOcorrenciaArquivoInfo> DocumentoTmsOcorrenciaArquivo { get; set; }
		
		public DbSet<DocumentoUaInfo> DocumentoUa { get; set; }
		
		public DbSet<DocumentoVolumeInfo> DocumentoVolume { get; set; }
		
		public DbSet<DocumentoWmsInfo> DocumentoWms { get; set; }
		
		public DbSet<DreInfo> Dre { get; set; }
		
		public DbSet<DreGrupoInfo> DreGrupo { get; set; }
		
		public DbSet<DreGrupoContaContabilInfo> DreGrupoContaContabil { get; set; }
		
		public DbSet<DreMovimentoGrupoInfo> DreMovimentoGrupo { get; set; }
		
		public DbSet<DreMovimentoGrupoContaContabilInfo> DreMovimentoGrupoContaContabil { get; set; }
		
		public DbSet<DreMovimentoGrupoContaContabilLancamentoInfo> DreMovimentoGrupoContaContabilLancamento { get; set; }
		
		public DbSet<DtInfo> Dt { get; set; }
		
		public DbSet<DtContaCorrenteInfo> DtContaCorrente { get; set; }
		
		public DbSet<DtContaCorrenteTipoLancamentoInfo> DtContaCorrenteTipoLancamento { get; set; }
		
		public DbSet<DtEletronicoInfo> DtEletronico { get; set; }
		
		public DbSet<DtEletronicoCstatusInfo> DtEletronicoCstatus { get; set; }
		
		public DbSet<DtMdfeInfo> DtMdfe { get; set; }
		
		public DbSet<DtPercursoInfo> DtPercurso { get; set; }
		
		public DbSet<DtPercursoEntregaInfo> DtPercursoEntrega { get; set; }
		
		public DbSet<DtRomaneioInfo> DtRomaneio { get; set; }
		
		public DbSet<DtTipoInfo> DtTipo { get; set; }
		
		public DbSet<DtTipoContratoInfo> DtTipoContrato { get; set; }

        public DbSet<DtObservacaoInfo> DtObservacao { get; set; }

        public DbSet<EdiInfo> Edi { get; set; }
		
		public DbSet<EdiArquivoInfo> EdiArquivo { get; set; }
		
		public DbSet<EmpresaInfo> Empresa { get; set; }
		
		public DbSet<EmpresaImagemInfo> EmpresaImagem { get; set; }
		
		public DbSet<EnderecoInfo> Endereco { get; set; }
		
		public DbSet<EstadoInfo> Estado { get; set; }
		
		public DbSet<EstadoFaixaCepInfo> EstadoFaixaCep { get; set; }
		
		public DbSet<EstatisticaSiteInfo> EstatisticaSite { get; set; }
		
		public DbSet<FilialInfo> Filial { get; set; }
		
		public DbSet<FilialCidadeSetorInfo> FilialCidadeSetor { get; set; }
		
		public DbSet<FornecedorInfo> Fornecedor { get; set; }
		
		public DbSet<FornecedorContaContabilInfo> FornecedorContaContabil { get; set; }
		
		public DbSet<FreteContratadoInfo> FreteContratado { get; set; }
		
		public DbSet<FreteContratadoDtInfo> FreteContratadoDt { get; set; }
		
		public DbSet<FrotaInfo> Frota { get; set; }

        public DbSet<IntegracaoInfo> Integracao { get; set; }

        public DbSet<IntegracaoItemInfo> IntegracaoItem { get; set; }
		
		public DbSet<LancamentoInfo> Lancamento { get; set; }
		
		public DbSet<LancamentoCentroCustoInfo> LancamentoCentroCusto { get; set; }
		
		public DbSet<LancamentoContabilInfo> LancamentoContabil { get; set; }
		
		public DbSet<LicenciamentoInfo> Licenciamento { get; set; }
		
		public DbSet<LicenciamentoMesInfo> LicenciamentoMes { get; set; }
		
		public DbSet<LogImportacaoInfo> LogImportacao { get; set; }
		
		public DbSet<LoteInfo> Lote { get; set; }
		
		public DbSet<LoteEletronicoInfo> LoteEletronico { get; set; }
		
		public DbSet<MessageInfo> Message { get; set; }
		
		public DbSet<ModalInfo> Modal { get; set; }
		
		public DbSet<ModoOperacaoInfo> ModoOperacao { get; set; }
		
		public DbSet<ModuloInfo> Modulo { get; set; }
		
		public DbSet<MotoristaInfo> Motorista { get; set; }
		
		public DbSet<MotoristaEventoInfo> MotoristaEvento { get; set; }
		
		public DbSet<MotoristaFilialInfo> MotoristaFilial { get; set; }
		
		public DbSet<MotoristaHistoricoInfo> MotoristaHistorico { get; set; }
		
		public DbSet<MotoristaImagemInfo> MotoristaImagem { get; set; }
		
		public DbSet<MotoristaTipoEventoInfo> MotoristaTipoEvento { get; set; }
		
		public DbSet<MovimentacaoInfo> Movimentacao { get; set; }
		
		public DbSet<MovimentacaoItemInfo> MovimentacaoItem { get; set; }
		
		public DbSet<NumeradorInfo> Numerador { get; set; }
		
		public DbSet<NumeradorDisponivelInfo> NumeradorDisponivel { get; set; }
		
		public DbSet<OcorrenciaInfo> Ocorrencia { get; set; }
		
		public DbSet<OcorrenciaSerieInfo> OcorrenciaSerie { get; set; }
		
		public DbSet<OperacaoInfo> Operacao { get; set; }
		
		public DbSet<PaisInfo> Pais { get; set; }
		
		public DbSet<ParceiroInfo> Parceiro { get; set; }
		
		public DbSet<ParceiroClienteInfo> ParceiroCliente { get; set; }
		
		public DbSet<ParceiroClienteConexaoInfo> ParceiroClienteConexao { get; set; }
		
		public DbSet<PessoaInfo> Pessoa { get; set; }
		
		public DbSet<PessoaContaInfo> PessoaConta { get; set; }
		
		public DbSet<PessoaEnderecoInfo> PessoaEndereco { get; set; }
		
		public DbSet<PessoaEstrangeiroInfo> PessoaEstrangeiro { get; set; }
		
		public DbSet<PessoaFisicaInfo> PessoaFisica { get; set; }
		
		public DbSet<PessoaImagemInfo> PessoaImagem { get; set; }
		
		public DbSet<PessoaJuridicaInfo> PessoaJuridica { get; set; }
		
		public DbSet<PessoaTipoInfo> PessoaTipo { get; set; }
		
		public DbSet<PessoaTipoEnderecoInfo> PessoaTipoEndereco { get; set; }
		
		public DbSet<PlantaInfo> Planta { get; set; }
		
		public DbSet<PlantaEnderecoInfo> PlantaEndereco { get; set; }
		
		public DbSet<PlantaFilialInfo> PlantaFilial { get; set; }
		
		public DbSet<PlantaTipoEnderecoInfo> PlantaTipoEndereco { get; set; }
		
		public DbSet<PortariaInfo> Portaria { get; set; }
		
		public DbSet<PortariaDtInfo> PortariaDt { get; set; }
		
		public DbSet<PortariaItemInfo> PortariaItem { get; set; }
		
		public DbSet<PortariaTipoAcessoInfo> PortariaTipoAcesso { get; set; }
		
		public DbSet<ProdutoInfo> Produto { get; set; }
		
		public DbSet<ProdutoClassificacaoInfo> ProdutoClassificacao { get; set; }
		
		public DbSet<ProdutoClienteInfo> ProdutoCliente { get; set; }
		
		public DbSet<ProdutoClienteMovimentoInfo> ProdutoClienteMovimento { get; set; }
		
		public DbSet<ProdutoCodificacaoInfo> ProdutoCodificacao { get; set; }
		
		public DbSet<ProdutoCodigoDeBarraInfo> ProdutoCodigoDeBarra { get; set; }
		
		public DbSet<ProdutoDivisaoInfo> ProdutoDivisao { get; set; }
		
		public DbSet<ProdutoDivisaoSaldoInfo> ProdutoDivisaoSaldo { get; set; }
		
		public DbSet<ProdutoDivisaoSaldoMovimentoInfo> ProdutoDivisaoSaldoMovimento { get; set; }
		
		public DbSet<ProdutoEmbalagemInfo> ProdutoEmbalagem { get; set; }
		
		public DbSet<ProdutoGrupoInfo> ProdutoGrupo { get; set; }
		
		public DbSet<ProdutoUnidadeMedidaInfo> ProdutoUnidadeMedida { get; set; }
		
		public DbSet<RegiaoInfo> Regiao { get; set; }
		
		public DbSet<RegiaoItemInfo> RegiaoItem { get; set; }
		
		public DbSet<RegiaoProprietarioInfo> RegiaoProprietario { get; set; }
		
		public DbSet<RequisicaoInfo> Requisicao { get; set; }
		
		public DbSet<RequisicaoItemInfo> RequisicaoItem { get; set; }
		
		public DbSet<RomaneioInfo> Romaneio { get; set; }
		
		public DbSet<RomaneioDocumentoInfo> RomaneioDocumento { get; set; }
		
		public DbSet<RomaneioDocumentoItemInfo> RomaneioDocumentoItem { get; set; }
		
		public DbSet<RomaneioPalletsInfo> RomaneioPallets { get; set; }
		
		public DbSet<RuaInfo> Rua { get; set; }
		
		public DbSet<ServicoInfo> Servico { get; set; }
		
		public DbSet<SetorInfo> Setor { get; set; }
		
		public DbSet<SetorCepInfo> SetorCep { get; set; }
		
		public DbSet<StatusInfo> Status { get; set; }
		
		public DbSet<TabelaFreteInfo> TabelaFrete { get; set; }
		
		public DbSet<TabelaFreteProdutoInfo> TabelaFreteProduto { get; set; }
		
		public DbSet<TabelaFreteRotaInfo> TabelaFreteRota { get; set; }
		
		public DbSet<TabelaFreteRotaModalInfo> TabelaFreteRotaModal { get; set; }
		
		public DbSet<TabelaFreteRotaModalValorInfo> TabelaFreteRotaModalValor { get; set; }
		
		public DbSet<TabelaFreteVigenciaInfo> TabelaFreteVigencia { get; set; }
		
		public DbSet<TipoControleEstoqueInfo> TipoControleEstoque { get; set; }
		
		public DbSet<TipoCteInfo> TipoCte { get; set; }
		
		public DbSet<TipoDocumentoInfo> TipoDocumento { get; set; }
		
		public DbSet<TipoOperacaoInfo> TipoOperacao { get; set; }
		
		public DbSet<TipoOperacaoEstoqueInfo> TipoOperacaoEstoque { get; set; }
		
		public DbSet<TipoRntrcInfo> TipoRntrc { get; set; }
		
		public DbSet<TipoSeguroInfo> TipoSeguro { get; set; }
		
		public DbSet<TipoServicoInfo> TipoServico { get; set; }
		
		public DbSet<TituloInfo> Titulo { get; set; }
		
		public DbSet<TituloDocumentoInfo> TituloDocumento { get; set; }
		
		public DbSet<TituloDuplicataInfo> TituloDuplicata { get; set; }
		
		public DbSet<TituloDuplicataHistoricoInfo> TituloDuplicataHistorico { get; set; }
		
		public DbSet<TituloTipoInfo> TituloTipo { get; set; }
		
		public DbSet<TransportadorInfo> Transportador { get; set; }
		
		public DbSet<TransportadorArquivoInfo> TransportadorArquivo { get; set; }
		
		public DbSet<TransportadorFreteInfo> TransportadorFrete { get; set; }
		
		public DbSet<TransportadorFreteRegiaoItemInfo> TransportadorFreteRegiaoItem { get; set; }
		
		public DbSet<TransportadorTipoContratoInfo> TransportadorTipoContrato { get; set; }
		
		public DbSet<TransportadorVeiculoInfo> TransportadorVeiculo { get; set; }
		
		public DbSet<TransportadorVeiculoTransportadorFreteInfo> TransportadorVeiculoTransportadorFrete { get; set; }
		
		public DbSet<UaInfo> Ua { get; set; }
		
		public DbSet<UaComposicaoInfo> UaComposicao { get; set; }
		
		public DbSet<UaLoteInfo> UaLote { get; set; }
		
		public DbSet<UsuarioTabelaFreteInfo> UsuarioTabelaFrete { get; set; }
		
		public DbSet<VeiculoInfo> Veiculo { get; set; }
		
		public DbSet<VeiculoCadastroInfo> VeiculoCadastro { get; set; }

        public DbSet<VeiculoEquipamentoGPSInfo> VeiculoEquipamentoGPS { get; set; }

        public DbSet<VeiculoImagemInfo> VeiculoImagem { get; set; }
		
		public DbSet<VeiculoLicenciamentoInfo> VeiculoLicenciamento { get; set; }
		
		public DbSet<VeiculoMarcaInfo> VeiculoMarca { get; set; }
		
		public DbSet<VeiculoModeloInfo> VeiculoModelo { get; set; }
		
		public DbSet<VeiculoRastreadorInfo> VeiculoRastreador { get; set; }
		
		public DbSet<VeiculoTipoInfo> VeiculoTipo { get; set; }
		
		public DbSet<VeiculoTipoCarroceriaInfo> VeiculoTipoCarroceria { get; set; }
		
		public DbSet<VeiculoTipoRodadoInfo> VeiculoTipoRodado { get; set; }
		
		public DbSet<VeiculoTracaoReboqueInfo> VeiculoTracaoReboque { get; set; }

		public DbSet<ProprietarioInfo> Proprietario { get; set; }

		public DbSet<TipoContatoInfo> TipoContato { get; set; }

		public DbSet<PessoaContatoInfo> PessoaContato { get; set; }

		public DbSet<DocumentoTrackingInfo> DocumentoTracking { get; set; }

		public DbSet<DocumentoTrackingOcorrenciaInfo> DocumentoTrackingOcorrencia { get; set; }

		public DbSet<DocumentoTrackingOcorrenciaArquivoInfo> DocumentoTrackingOcorrenciaArquivo { get; set; }

		public DbSet<UserClienteInfo> UserCliente { get; set; }

		//public DbSet<PlantaUserDivisaoInfo> PlantaUserDivisao { get; set; } //AQ

		public DbSet<ProdutoDivisaoUserInfo> ProdutoDivisaoUser { get; set; } //AQ

        public DbSet<ProdutoDeParaInfo> ProdutoDePara { get; set; } // AQ


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_conn);
		}
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			RegisterMaps(builder);
		}
		
		public static void RegisterMaps(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ApoliceMap());
			builder.ApplyConfiguration(new ApoliceAtuadorMap());
			builder.ApplyConfiguration(new ApoliceItemMap());
			builder.ApplyConfiguration(new BairroMap());
			builder.ApplyConfiguration(new BairroFaixaCepMap());
			builder.ApplyConfiguration(new BancoMap());
			builder.ApplyConfiguration(new BancoAgendamentoMap());
			builder.ApplyConfiguration(new BancoCarteiraMap());
			builder.ApplyConfiguration(new BancoEspecieMap());
			builder.ApplyConfiguration(new BancoInstrucaoMap());
			builder.ApplyConfiguration(new BancoInstrucaoProtestoMap());
			builder.ApplyConfiguration(new BancoModalidadeMap());
			builder.ApplyConfiguration(new BancoOcorrenciaRejeicaoMap());
			builder.ApplyConfiguration(new BancoOcorrenciaRemessaMap());
			builder.ApplyConfiguration(new BancoOcorrenciaRetornoMap());
			builder.ApplyConfiguration(new BancoTipoMovimentoMap());
			builder.ApplyConfiguration(new BorderoMap());
			builder.ApplyConfiguration(new BorderoTituloDuplicataMap());
			builder.ApplyConfiguration(new CentroCustoMap());
			builder.ApplyConfiguration(new CfopMap());
			builder.ApplyConfiguration(new CidadeMap());
			builder.ApplyConfiguration(new CidadeFaixaCepMap());
			builder.ApplyConfiguration(new CiotMap());
			builder.ApplyConfiguration(new ClienteMap());
			builder.ApplyConfiguration(new ClienteContaContabilMap());
			builder.ApplyConfiguration(new ClienteEdiMap());
			builder.ApplyConfiguration(new ClienteTmsMap());
			builder.ApplyConfiguration(new ClienteWmsMap());
			builder.ApplyConfiguration(new CodigoStatusMap());
			builder.ApplyConfiguration(new CondicaoFaturamentoMap());
			builder.ApplyConfiguration(new CondicaoFaturamentoItemMap());
			builder.ApplyConfiguration(new ConexaoMap());
			builder.ApplyConfiguration(new ConexaoClienteMap());
			builder.ApplyConfiguration(new ConferenciaMap());
			builder.ApplyConfiguration(new ConferenciaUaMap());
			builder.ApplyConfiguration(new ConferenciaUaItemMap());
			builder.ApplyConfiguration(new ConfigMap());
			builder.ApplyConfiguration(new ConfiguracaoMap());
			builder.ApplyConfiguration(new ContaContabilMap());
			builder.ApplyConfiguration(new ContaCorrenteMap());
			builder.ApplyConfiguration(new ContaCorrenteCarteiraMap());
			builder.ApplyConfiguration(new ContaCorrenteMovimentacaoMap());
			builder.ApplyConfiguration(new ContaCorrenteMovimentacaoDuplicataMap());
			builder.ApplyConfiguration(new ContratoMap());
			builder.ApplyConfiguration(new CotacaoMap());
			builder.ApplyConfiguration(new CotacaoItemMap());
			builder.ApplyConfiguration(new DdaMap());
			builder.ApplyConfiguration(new DdaImagemMap());
			builder.ApplyConfiguration(new DeParaMap());
			builder.ApplyConfiguration(new DocumentoMap());
			builder.ApplyConfiguration(new DocumentoColMap());
			builder.ApplyConfiguration(new DocumentoCteMap());
			builder.ApplyConfiguration(new DocumentoEletronicoMap());
			builder.ApplyConfiguration(new DocumentoEletronicoCstatusMap());
			builder.ApplyConfiguration(new DocumentoEnderecoServicoMap());
			builder.ApplyConfiguration(new DocumentoFaturarMap());
			builder.ApplyConfiguration(new DocumentoFinMap());
			builder.ApplyConfiguration(new DocumentoFreteMap());
			builder.ApplyConfiguration(new DocumentoImpostoMap());
			builder.ApplyConfiguration(new DocumentoItemMap());
			builder.ApplyConfiguration(new DocumentoNfeMap());
			builder.ApplyConfiguration(new DocumentoNfeFreteMap());
			builder.ApplyConfiguration(new DocumentoObservacaoMap());
			builder.ApplyConfiguration(new DocumentoPedMap());
			builder.ApplyConfiguration(new DocumentoRegiaoMap());
			builder.ApplyConfiguration(new DocumentoRelacionadoMap());
			builder.ApplyConfiguration(new DocumentoTmsMap());
			builder.ApplyConfiguration(new DocumentoTmsOcorrenciaMap());
			builder.ApplyConfiguration(new DocumentoTmsOcorrenciaArquivoMap());
			builder.ApplyConfiguration(new DocumentoUaMap());
			builder.ApplyConfiguration(new DocumentoVolumeMap());
			builder.ApplyConfiguration(new DocumentoWmsMap());
			builder.ApplyConfiguration(new DreMap());
			builder.ApplyConfiguration(new DreGrupoMap());
			builder.ApplyConfiguration(new DreGrupoContaContabilMap());
			builder.ApplyConfiguration(new DreMovimentoGrupoMap());
			builder.ApplyConfiguration(new DreMovimentoGrupoContaContabilMap());
			builder.ApplyConfiguration(new DreMovimentoGrupoContaContabilLancamentoMap());
			builder.ApplyConfiguration(new DtMap());
			builder.ApplyConfiguration(new DtContaCorrenteMap());
			builder.ApplyConfiguration(new DtContaCorrenteTipoLancamentoMap());
			builder.ApplyConfiguration(new DtEletronicoMap());
			builder.ApplyConfiguration(new DtEletronicoCstatusMap());
			builder.ApplyConfiguration(new DtMdfeMap());
			builder.ApplyConfiguration(new DtPercursoMap());
			builder.ApplyConfiguration(new DtPercursoEntregaMap());
			builder.ApplyConfiguration(new DtRomaneioMap());
			builder.ApplyConfiguration(new DtTipoMap());
			builder.ApplyConfiguration(new DtTipoContratoMap());
			builder.ApplyConfiguration(new EdiMap());
			builder.ApplyConfiguration(new EdiArquivoMap());
			builder.ApplyConfiguration(new EmpresaMap());
			builder.ApplyConfiguration(new EmpresaImagemMap());
			builder.ApplyConfiguration(new EnderecoMap());
			builder.ApplyConfiguration(new EstadoMap());
			builder.ApplyConfiguration(new EstadoFaixaCepMap());
			builder.ApplyConfiguration(new EstatisticaSiteMap());
            builder.ApplyConfiguration(new EquipamentoGPSMap());
            builder.ApplyConfiguration(new FilialMap());
			builder.ApplyConfiguration(new FilialCidadeSetorMap());
			builder.ApplyConfiguration(new FornecedorMap());
			builder.ApplyConfiguration(new FornecedorContaContabilMap());
			builder.ApplyConfiguration(new FreteContratadoMap());
			builder.ApplyConfiguration(new FreteContratadoDtMap());
			builder.ApplyConfiguration(new FrotaMap());
			builder.ApplyConfiguration(new LancamentoMap());
			builder.ApplyConfiguration(new LancamentoCentroCustoMap());
			builder.ApplyConfiguration(new LancamentoContabilMap());
			builder.ApplyConfiguration(new LicenciamentoMap());
			builder.ApplyConfiguration(new LicenciamentoMesMap());
			builder.ApplyConfiguration(new LogImportacaoMap());
			builder.ApplyConfiguration(new LoteMap());
			builder.ApplyConfiguration(new LoteEletronicoMap());
			builder.ApplyConfiguration(new MessageMap());
			builder.ApplyConfiguration(new ModalMap());
			builder.ApplyConfiguration(new ModoOperacaoMap());
			builder.ApplyConfiguration(new ModuloMap());
			builder.ApplyConfiguration(new MotoristaMap());
			builder.ApplyConfiguration(new MotoristaEventoMap());
			builder.ApplyConfiguration(new MotoristaFilialMap());
			builder.ApplyConfiguration(new MotoristaHistoricoMap());
			builder.ApplyConfiguration(new MotoristaImagemMap());
			builder.ApplyConfiguration(new MotoristaTipoEventoMap());
			builder.ApplyConfiguration(new MovimentacaoMap());
			builder.ApplyConfiguration(new MovimentacaoItemMap());
			builder.ApplyConfiguration(new NumeradorMap());
			builder.ApplyConfiguration(new NumeradorDisponivelMap());
			builder.ApplyConfiguration(new OcorrenciaMap());
			builder.ApplyConfiguration(new OcorrenciaSerieMap());
			builder.ApplyConfiguration(new OperacaoMap());
			builder.ApplyConfiguration(new PaisMap());
			builder.ApplyConfiguration(new ParceiroMap());
			builder.ApplyConfiguration(new ParceiroClienteMap());
			builder.ApplyConfiguration(new ParceiroClienteConexaoMap());
			builder.ApplyConfiguration(new PessoaMap());
			builder.ApplyConfiguration(new PessoaContaMap());
			builder.ApplyConfiguration(new PessoaEnderecoMap());
			builder.ApplyConfiguration(new PessoaEstrangeiroMap());
			builder.ApplyConfiguration(new PessoaFisicaMap());
			builder.ApplyConfiguration(new PessoaImagemMap());
			builder.ApplyConfiguration(new PessoaJuridicaMap());
			builder.ApplyConfiguration(new PessoaTipoMap());
			builder.ApplyConfiguration(new PessoaTipoEnderecoMap());
			builder.ApplyConfiguration(new PlantaMap());
			builder.ApplyConfiguration(new PlantaEnderecoMap());
			builder.ApplyConfiguration(new PlantaFilialMap());
			builder.ApplyConfiguration(new PlantaTipoEnderecoMap());
			builder.ApplyConfiguration(new PortariaMap());
			builder.ApplyConfiguration(new PortariaDtMap());
			builder.ApplyConfiguration(new PortariaItemMap());
			builder.ApplyConfiguration(new PortariaTipoAcessoMap());
			builder.ApplyConfiguration(new ProdutoMap());
			builder.ApplyConfiguration(new ProdutoClassificacaoMap());
			builder.ApplyConfiguration(new ProdutoClienteMap());
			builder.ApplyConfiguration(new ProdutoClienteMovimentoMap());
			builder.ApplyConfiguration(new ProdutoCodificacaoMap());
			builder.ApplyConfiguration(new ProdutoCodigoDeBarraMap());
			builder.ApplyConfiguration(new ProdutoDivisaoMap());
			builder.ApplyConfiguration(new ProdutoDivisaoSaldoMap());
			builder.ApplyConfiguration(new ProdutoDivisaoSaldoMovimentoMap());
			builder.ApplyConfiguration(new ProdutoEmbalagemMap());
			builder.ApplyConfiguration(new ProdutoGrupoMap());
			builder.ApplyConfiguration(new ProdutoUnidadeMedidaMap());
			builder.ApplyConfiguration(new RegiaoMap());
			builder.ApplyConfiguration(new RegiaoItemMap());
			builder.ApplyConfiguration(new RegiaoProprietarioMap());
			builder.ApplyConfiguration(new RequisicaoMap());
			builder.ApplyConfiguration(new RequisicaoItemMap());
			builder.ApplyConfiguration(new RomaneioMap());
			builder.ApplyConfiguration(new RomaneioDocumentoMap());
			builder.ApplyConfiguration(new RomaneioDocumentoItemMap());
			builder.ApplyConfiguration(new RomaneioPalletsMap());
			builder.ApplyConfiguration(new RuaMap());
			builder.ApplyConfiguration(new ServicoMap());
			builder.ApplyConfiguration(new SetorMap());
			builder.ApplyConfiguration(new SetorCepMap());
			builder.ApplyConfiguration(new StatusMap());
			builder.ApplyConfiguration(new TabelaFreteMap());
			builder.ApplyConfiguration(new TabelaFreteProdutoMap());
			builder.ApplyConfiguration(new TabelaFreteRotaMap());
			builder.ApplyConfiguration(new TabelaFreteRotaModalMap());
			builder.ApplyConfiguration(new TabelaFreteRotaModalValorMap());
			builder.ApplyConfiguration(new TabelaFreteVigenciaMap());
			builder.ApplyConfiguration(new TipoControleEstoqueMap());
			builder.ApplyConfiguration(new TipoCteMap());
			builder.ApplyConfiguration(new TipoDocumentoMap());
			builder.ApplyConfiguration(new TipoOperacaoMap());
			builder.ApplyConfiguration(new TipoOperacaoEstoqueMap());
			builder.ApplyConfiguration(new TipoRntrcMap());
			builder.ApplyConfiguration(new TipoSeguroMap());
			builder.ApplyConfiguration(new TipoServicoMap());
			builder.ApplyConfiguration(new TituloMap());
			builder.ApplyConfiguration(new TituloDocumentoMap());
			builder.ApplyConfiguration(new TituloDuplicataMap());
			builder.ApplyConfiguration(new TituloDuplicataHistoricoMap());
			builder.ApplyConfiguration(new TituloTipoMap());
			builder.ApplyConfiguration(new TransportadorMap());
			builder.ApplyConfiguration(new TransportadorArquivoMap());
			builder.ApplyConfiguration(new TransportadorFreteMap());
			builder.ApplyConfiguration(new TransportadorFreteRegiaoItemMap());
			builder.ApplyConfiguration(new TransportadorTipoContratoMap());
			builder.ApplyConfiguration(new TransportadorVeiculoMap());
			builder.ApplyConfiguration(new TransportadorVeiculoTransportadorFreteMap());
			builder.ApplyConfiguration(new UaMap());
			builder.ApplyConfiguration(new UaComposicaoMap());
			builder.ApplyConfiguration(new UaLoteMap());
			builder.ApplyConfiguration(new UsuarioTabelaFreteMap());
			builder.ApplyConfiguration(new VeiculoMap());
			builder.ApplyConfiguration(new VeiculoCadastroMap());
            builder.ApplyConfiguration(new VeiculoEquipamentoGPSMap());
            builder.ApplyConfiguration(new VeiculoImagemMap());
			builder.ApplyConfiguration(new VeiculoLicenciamentoMap());
			builder.ApplyConfiguration(new VeiculoMarcaMap());
			builder.ApplyConfiguration(new VeiculoModeloMap());
			builder.ApplyConfiguration(new VeiculoRastreadorMap());
			builder.ApplyConfiguration(new VeiculoTipoMap());
			builder.ApplyConfiguration(new VeiculoTipoCarroceriaMap());
			builder.ApplyConfiguration(new VeiculoTipoRodadoMap());
			builder.ApplyConfiguration(new ProprietarioMap());
			builder.ApplyConfiguration(new TipoContatoMap());
			builder.ApplyConfiguration(new VeiculoTracaoReboqueMap());
			builder.ApplyConfiguration(new PessoaContatoMap());
            builder.ApplyConfiguration(new ProdutoDivisaoUserMap());
            builder.ApplyConfiguration(new ProdutoDeParaMap());
            builder.ApplyConfiguration(new UserClienteMap());


			Cg.Infra.Data.Contexts.CgDataContext.RegisterMaps(builder);
			builder.ApplyConfiguration(new AmountTypeMap());
			builder.ApplyConfiguration(new IngredientMap());
			builder.ApplyConfiguration(new RecipeMap());
			builder.ApplyConfiguration(new RecipeIngredientMap());
			builder.ApplyConfiguration(new ShoplistMap());
			builder.ApplyConfiguration(new ShoplistIngredientMap());
		}
	}
}