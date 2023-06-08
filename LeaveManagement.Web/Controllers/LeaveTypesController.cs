using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Supervisor)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();

            if (leaveTypes == null)
            {
                return NotFound();
            }

            var leaveTypesVM = _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

            return View(leaveTypesVM);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        [Authorize(Roles = Roles.Administrator)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                await _leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            // Récupérer l'enregistrement original depuis la bdd et vérifier si il existe
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Faire le mapping en ne mettant à jour que les champ modifiés
                    _mapper.Map(leaveTypeVM, leaveType);
                    await _leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _leaveTypeRepository.Exists(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Delete/5
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocationRepository.LeaveAllocation(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
