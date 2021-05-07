using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spMedicalGroup_webApiDB.Domains;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Context
{
    public partial class SpMedicalGroupContext : DbContext
    {
        public SpMedicalGroupContext()
        {
        }

        public SpMedicalGroupContext(DbContextOptions<SpMedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<clinica> clinicas { get; set; }
        public virtual DbSet<consulta> consultas { get; set; }
        public virtual DbSet<especialidade> especialidades { get; set; }
        public virtual DbSet<medico> medicos { get; set; }
        public virtual DbSet<paciente> pacientes { get; set; }
        public virtual DbSet<situacao> situacoes { get; set; }
        public virtual DbSet<tiposUsuario> tiposUsuarios { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ROBERT-025; Initial Catalog=SPMedicalGroup; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<clinica>(entity =>
            {
                entity.HasKey(e => e.idClinica)
                    .HasName("PK__clinicas__C73A6055A180675B");

                entity.HasIndex(e => e.cnpj, "UQ__clinicas__35BD3E48204747CC")
                    .IsUnique();

                entity.HasIndex(e => e.endereco, "UQ__clinicas__9456D406E6BAA3F1")
                    .IsUnique();

                entity.Property(e => e.cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.nomeClinica)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.razaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<consulta>(entity =>
            {
                entity.HasKey(e => e.idConsulta)
                    .HasName("PK__consulta__CA9C61F56E734E9D");

                entity.Property(e => e.dataConsulta).HasColumnType("smalldatetime");

                entity.Property(e => e.idSituacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idMedicoNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idMedico)
                    .HasConstraintName("FK__consultas__idMed__3F466844");

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idPaciente)
                    .HasConstraintName("FK__consultas__idPac__3E52440B");

                entity.HasOne(d => d.idSituacaoNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idSituacao)
                    .HasConstraintName("FK__consultas__idSit__403A8C7D");
            });

            modelBuilder.Entity<especialidade>(entity =>
            {
                entity.HasKey(e => e.idEspecialidade)
                    .HasName("PK__especial__4096980522113FC6");

                entity.HasIndex(e => e.nome, "UQ__especial__6F71C0DC5F1A85EE")
                    .IsUnique();

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<medico>(entity =>
            {
                entity.HasKey(e => e.idMedico)
                    .HasName("PK__medicos__4E03DEBAB3DAEB6D");

                entity.HasIndex(e => e.crm, "UQ__medicos__D836F7D188210BF0")
                    .IsUnique();

                entity.Property(e => e.crm)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.idClinicaNavigation)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.idClinica)
                    .HasConstraintName("FK__medicos__idClini__3B75D760");

                entity.HasOne(d => d.idEspecialidadeNavigation)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.idEspecialidade)
                    .HasConstraintName("FK__medicos__idEspec__3A81B327");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.idUsuario)
                    .HasConstraintName("FK__medicos__idUsuar__398D8EEE");
            });

            modelBuilder.Entity<paciente>(entity =>
            {
                entity.HasKey(e => e.idPaciente)
                    .HasName("PK__paciente__F48A08F26795AFAE");

                entity.HasIndex(e => e.rg, "UQ__paciente__321433104927E93C")
                    .IsUnique();

                entity.HasIndex(e => e.cpf, "UQ__paciente__D836E71F0AEB69DE")
                    .IsUnique();

                entity.Property(e => e.cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.endereco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.pacientes)
                    .HasForeignKey(d => d.idUsuario)
                    .HasConstraintName("FK__pacientes__idUsu__35BCFE0A");
            });

            modelBuilder.Entity<situacao>(entity =>
            {
                entity.HasKey(e => e.idSituacao)
                    .HasName("PK__situacoe__12AFD19702D8A820");

                entity.Property(e => e.descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tiposUsuario>(entity =>
            {
                entity.HasKey(e => e.idTipo)
                    .HasName("PK__tiposUsu__BDD0DFE1EBAEC76E");

                entity.HasIndex(e => e.tituloTipo, "UQ__tiposUsu__4908F7FA0044D310")
                    .IsUnique();

                entity.Property(e => e.tituloTipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario)
                    .HasName("PK__usuarios__645723A6D71DBDFE");

                entity.HasIndex(e => e.email, "UQ__usuarios__AB6E61645249EC53")
                    .IsUnique();

                entity.Property(e => e.dataNascimento).HasColumnType("date");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.senha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.idTipoNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.idTipo)
                    .HasConstraintName("FK__usuarios__idTipo__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
