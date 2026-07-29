package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Paciente;
import com.utp.sistemas.services.PacienteService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/pacientes")
public class PacienteController {

    @Autowired
    private PacienteService pacienteService;

    @PostMapping
    public Paciente createPaciente(@RequestBody Paciente paciente) {
        return pacienteService.createPaciente(paciente);
    }

    @GetMapping
    public List<Paciente> getAllPacientes() {
        return pacienteService.getAllPacientes();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Paciente> getPacienteById(@PathVariable Integer id) {
        return pacienteService.getPacienteById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Paciente> updatePaciente(@PathVariable Integer id, @RequestBody Paciente pacienteDetails) {
        Paciente updatedPaciente = pacienteService.updatePaciente(id, pacienteDetails);
        return updatedPaciente != null ? ResponseEntity.ok(updatedPaciente) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletePaciente(@PathVariable Integer id) {
        pacienteService.deletePaciente(id);
        return ResponseEntity.noContent().build();
    }
}