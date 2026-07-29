package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Medico;
import com.utp.sistemas.services.MedicoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/medicos")
public class MedicoController {

    @Autowired
    private MedicoService medicoService;

    @PostMapping
    public Medico createMedico(@RequestBody Medico medico) {
        return medicoService.createMedico(medico);
    }

    @GetMapping
    public List<Medico> getAllMedicos() {
        return medicoService.getAllMedicos();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Medico> getMedicoById(@PathVariable Integer id) {
        return medicoService.getMedicoById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Medico> updateMedico(@PathVariable Integer id, @RequestBody Medico medicoDetails) {
        Medico updatedMedico = medicoService.updateMedico(id, medicoDetails);
        return updatedMedico != null ? ResponseEntity.ok(updatedMedico) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteMedico(@PathVariable Integer id) {
        medicoService.deleteMedico(id);
        return ResponseEntity.noContent().build();
    }
}