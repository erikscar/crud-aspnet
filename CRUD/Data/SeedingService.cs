using CRUD.Models.Enums;
using CRUD.Models;
using NuGet.Protocol.Plugins;

namespace CRUD.Data
{
    public class SeedingService
    {
        private CRUDContext _context;

        //Injeção de Dependência
        //Quando um SeedingService fore Inicializado ele irá receber uma instância do context
        public SeedingService(CRUDContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //Testando se há algum registro na tabela
            if(_context.Department.Any() ||
               _context.Provider.Any() ||
               _context.ProvidersRecord.Any())
            {
                return; //Banco de Dados Já Populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Provider s1 = new Provider(1, "W Lenin", "wlenin@urss.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Provider s2 = new Provider(2, "K Marx", "kmarx@manifesto.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Provider s3 = new Provider(3, "C Marighela", "cmariga@luta.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Provider s4 = new Provider(4, "L C Prestes", "lcprestes@pcb.com", new DateTime(1998, 4, 21), 1000.0, d4);
            Provider s5 = new Provider(5, "Rosa Luxemburgo", "rosaluxemburgo@urss.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Provider s6 = new Provider(6, "Olga Benario", "obenario@revolucao.com", new DateTime(1998, 4, 21), 1000.0, d2);

            ProvidersRecord r1 = new ProvidersRecord(1, new DateTime(2022, 08, 25), 11000.0, SaleStatus.Billed, s1);
            ProvidersRecord r2 = new ProvidersRecord(2, new DateTime(2022, 08, 26), 7000.0, SaleStatus.Canceled, s2);
            ProvidersRecord r3 = new ProvidersRecord(3, new DateTime(2022, 08, 27), 1000.0, SaleStatus.Pending, s3);
            ProvidersRecord r4 = new ProvidersRecord(4, new DateTime(2022, 08, 28), 8000.0, SaleStatus.Billed, s4);
            ProvidersRecord  r5 = new ProvidersRecord(5, new DateTime(2022, 08, 29), 31000.0, SaleStatus.Canceled, s5);
            ProvidersRecord r6 = new ProvidersRecord(6, new DateTime(2022, 08, 15), 2000.0, SaleStatus.Pending, s6);
            ProvidersRecord r7 = new ProvidersRecord(7, new DateTime(2022, 08, 15), 12000.0, SaleStatus.Billed, s2);
            ProvidersRecord r8 = new ProvidersRecord(8, new DateTime(2022, 08, 16), 21000.0, SaleStatus.Billed, s4);
            ProvidersRecord r9 = new ProvidersRecord(9, new DateTime(2022, 08, 17), 5000.0, SaleStatus.Pending, s3);
            ProvidersRecord r10 = new ProvidersRecord(10, new DateTime(2022, 08, 18), 6000.0, SaleStatus.Billed, s5);
            ProvidersRecord r11 = new ProvidersRecord(11, new DateTime(2022, 08, 19), 7000.0, SaleStatus.Billed, s1);
            ProvidersRecord r12 = new ProvidersRecord(12, new DateTime(2022, 08, 20), 8000.0, SaleStatus.Pending, s6);
            ProvidersRecord r13 = new ProvidersRecord(13, new DateTime(2022, 08, 21), 9000.0, SaleStatus.Billed, s5);
            ProvidersRecord r14 = new ProvidersRecord(14, new DateTime(2022, 08, 21), 10000.0, SaleStatus.Canceled, s4);
            ProvidersRecord r15 = new ProvidersRecord(15, new DateTime(2022, 08, 22), 11000.0, SaleStatus.Billed, s3);
            ProvidersRecord r16 = new ProvidersRecord(16, new DateTime(2022, 08, 23), 12000.0, SaleStatus.Canceled, s2);
            ProvidersRecord r17 = new ProvidersRecord(17, new DateTime(2022, 08, 22), 12000.0, SaleStatus.Billed, s1);
            ProvidersRecord r18 = new ProvidersRecord(18, new DateTime(2022, 08, 23), 13000.0, SaleStatus.Billed, s1);
            ProvidersRecord r19 = new ProvidersRecord(19, new DateTime(2022, 08, 24), 14000.0, SaleStatus.Billed, s2);
            ProvidersRecord r20 = new ProvidersRecord(20, new DateTime(2022, 08, 25), 13000.0, SaleStatus.Billed, s2);
            ProvidersRecord r21 = new ProvidersRecord(21, new DateTime(2022, 08, 02), 15000.0, SaleStatus.Billed, s3);
            ProvidersRecord r22 = new ProvidersRecord(22, new DateTime(2022, 08, 03), 15000.0, SaleStatus.Billed, s4);
            ProvidersRecord r23 = new ProvidersRecord(23, new DateTime(2022, 08, 04), 17000.0, SaleStatus.Billed, s4);
            ProvidersRecord r24 = new ProvidersRecord(24, new DateTime(2022, 08, 04), 19000.0, SaleStatus.Billed, s5);
            ProvidersRecord r25 = new ProvidersRecord(25, new DateTime(2022, 08, 06), 11000.0, SaleStatus.Billed, s6);
            ProvidersRecord r26 = new ProvidersRecord(26, new DateTime(2022, 08, 09), 10000.0, SaleStatus.Canceled, s6);
            ProvidersRecord r27 = new ProvidersRecord(27, new DateTime(2022, 08, 07), 15000.0, SaleStatus.Billed, s5);
            ProvidersRecord r28 = new ProvidersRecord(28, new DateTime(2022, 08, 10), 17000.0, SaleStatus.Billed, s4);
            ProvidersRecord r29 = new ProvidersRecord(29, new DateTime(2022, 08, 11), 16000.0, SaleStatus.Billed, s5);
            ProvidersRecord r30 = new ProvidersRecord(30, new DateTime(2022, 08, 12), 21000.0, SaleStatus.Pending, s2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Provider.AddRange(s1, s2, s3, s4, s5, s6);
            _context.ProvidersRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);
            _context.SaveChanges();
        }
    }
}
