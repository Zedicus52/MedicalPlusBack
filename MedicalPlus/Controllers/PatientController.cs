using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/patient")]
    [Authorize]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public PatientController(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {

            List<PatientModel> result = new List<PatientModel>();
            var patients = await _unitOfWorks.PatientRepo.GetAll();
            var fios = await _unitOfWorks.FioRepo.GetAll();
            var genders = await _unitOfWorks.GenderRepo.GetAll();

            foreach (var patient in patients)
            {
                PatientModel model = new PatientModel
                {
                    PhoneNumber = patient.PhoneNumber,
                    ApplicationDate = patient.ApplicationDate,
                    BirthDate = patient.BirthDate,
                    IdPatient = patient.IdPatient,
                    MedicalCardNumber = patient.MedicalCardNumber,
                };
                Fio fio = fios.FirstOrDefault(x => x.IdFio.Equals(patient.IdFio));
                Gender gender = genders.FirstOrDefault(x => x.IdGender.Equals(patient.IdGender));
                model.Fio = new FioModel(fio.IdFio, fio.Name, fio.Surname, fio.Patronymic);
                model.Gender = new GenderModel(gender.IdGender, gender.Name);
                result.Add(model);
            }
            
            return Ok(result);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(this._unitOfWorks.PatientRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            this._unitOfWorks.PatientRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] PatientModel patient)
        {
            Patient dbPatient = _unitOfWorks.PatientRepo.GetAll().Result.FirstOrDefault(p => p.IdPatient.Equals(patient.IdPatient));
            if (dbPatient != null)
            {
                dbPatient.BirthDate = patient.BirthDate;
                dbPatient.PhoneNumber = patient.PhoneNumber;
                dbPatient.MedicalCardNumber = patient.MedicalCardNumber;    

                Fio fio = _unitOfWorks.FioRepo.GetAll().Result.FirstOrDefault(f => f.IdFio.Equals(patient.Fio.IdFio));
                if (fio != null)
                {
                    fio.Surname = patient.Fio.Surname;
                    fio.Name = patient.Fio.Name;
                    fio.Patronymic = patient.Fio.Patronymic;
                }

                Gender gender = _unitOfWorks.GenderRepo.GetAll().Result.FirstOrDefault(g => g.IdGender.Equals(patient.Gender.IdGender));
                if (gender != null)
                    dbPatient.IdGender = gender.IdGender;
            }
            _unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]PatientModel patient)
        {
            Fio fio = new Fio(patient.Fio.Name, patient.Fio.Surname, patient.Fio.Patronymic);
            _unitOfWorks.FioRepo.Add(fio);
            _unitOfWorks.Commit();
           
            Gender? gender = _unitOfWorks.GenderRepo.GetAll().Result.FirstOrDefault(g => g.IdGender.Equals(patient.Gender.IdGender));
            if (gender == null)
            {
                gender = new Gender(patient.Gender.Name);
                _unitOfWorks.GenderRepo.Add(gender);
                _unitOfWorks.Commit();
            }
            
            Patient patientModel = new Patient(patient.PhoneNumber,patient.MedicalCardNumber, patient.BirthDate, patient.ApplicationDate, fio, gender);
            _unitOfWorks.PatientRepo.Add(patientModel);
            _unitOfWorks.Commit();
            return Ok();
        }
    }
}
